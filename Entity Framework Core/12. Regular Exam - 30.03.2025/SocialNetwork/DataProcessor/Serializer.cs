using Newtonsoft.Json;
using SocialNetwork.Common;
using SocialNetwork.Data;
using SocialNetwork.Data.Models.Enums;
using SocialNetwork.DataProcessor.ExportDTOs;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            var userWithFriendsCountandPost = dbContext
                .Users
                .OrderBy(u => u.Username)
                .Select(u => new ExportUserDto
                {
                    Friendships=(dbContext.Friendships
                                .Where(f=>f.UserOneId==u.Id)
                                .Count() 
                                + dbContext.Friendships
                                .Where(f => f.UserTwoId == u.Id)
                                .Count()).ToString(),
                    Username=u.Username,
                    Posts = u.Posts
                                    .OrderBy(p=>p.Id)
                                    .Select(p=> new ExportPostDto
                                            {
                                                Content=p.Content,
                                                CreatedAt=p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                                             }) 
                                            .ToArray()

                })
                .ToArray();

            var result = XmlHelper
                .Serialize(userWithFriendsCountandPost, "Users");

            return result;

        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {

            var conversationsWithMessages = dbContext
                .Conversations
                .OrderBy(c=>c.StartedAt)
                .Select(c => new
                {
                    Id=c.Id,
                    Title=c.Title,
                    StartedAt=c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    Messages = c.Messages
                                        .OrderBy(m=>m.SentAt)
                                        .Select(m=> new
                                        {
                                            Content=m.Content,
                                            SentAt=m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                                            Status=(Status)m.Status,
                                            SenderUsername=m.Sender.Username

                                        })
                                        .ToArray()

                })
                .ToArray();

            var result = JsonConvert
                    .SerializeObject(conversationsWithMessages,Formatting.Indented);

            return result;
        }
    }
}
