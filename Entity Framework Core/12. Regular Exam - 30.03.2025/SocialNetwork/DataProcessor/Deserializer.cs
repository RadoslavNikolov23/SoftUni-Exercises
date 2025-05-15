using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocialNetwork.Common;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Enums;
using SocialNetwork.DataProcessor.ImportDTOs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            StringBuilder resultSb = new StringBuilder();
            const string rootName = "Messages";

            ImportMessagesDto[]? importMessagesDtos = XmlHelper
                .Desirialize<ImportMessagesDto[]>(xmlString, rootName);

            if(importMessagesDtos != null &&  importMessagesDtos.Length > 0)
            {
                ICollection<Message> messagesToAdd = new List<Message>();

                foreach(var messageDto in importMessagesDtos)
                {
                    if (!IsValid(messageDto))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }


                    bool isSentAtValid = DateTime
                                    .TryParseExact(messageDto.SentAt,
                                    "yyyy-MM-ddTHH:mm:ss",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out DateTime sentAtParse);

                    bool isStatusValid = Enum
                                .TryParse<Status>(messageDto.Status,
                                            out Status statusParse);

                    bool isConversationIdValid = int
                                .TryParse(messageDto.ConversationId,
                                           out int conversationIdParse);

                    bool isSenderIdValid = int
                                .TryParse(messageDto.SenderId,
                                           out int senderIdParse);

                    if(!isSentAtValid || !isStatusValid || !isConversationIdValid || !isSenderIdValid)
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!dbContext.Conversations.Any(c => c.Id == conversationIdParse)
                        || !dbContext.Users.Any(u=>u.Id==senderIdParse))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (messagesToAdd.Any(m => m.ConversationId == conversationIdParse))
                    {
                        if (messagesToAdd.Any(m => m.Content == messageDto.Content
                                             && m.SentAt == sentAtParse
                                             && m.Status == statusParse
                                             && m.SenderId == senderIdParse))
                        {
                            resultSb.AppendLine(DuplicatedDataMessage);
                            continue;
                        }
                    }

                    Message message = new Message
                    {
                        Content = messageDto.Content,
                        SentAt = sentAtParse,
                        Status = statusParse,
                        ConversationId = conversationIdParse,
                        SenderId = senderIdParse,
                    };
                    
                    messagesToAdd.Add(message);
                    resultSb.AppendLine(string.Format(SuccessfullyImportedMessageEntity, sentAtParse.ToString("yyyy-MM-ddTHH:mm:ss"), statusParse));

                }

                dbContext.Messages.AddRange(messagesToAdd);
                dbContext.SaveChanges();

            }


            return resultSb.ToString().TrimEnd();
        }

        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {
            StringBuilder resulstSb = new StringBuilder();


            ImportPostDto[]? importPostDtos = JsonConvert
                .DeserializeObject<ImportPostDto[]>(jsonString);

            if(importPostDtos != null && importPostDtos.Length > 0)
            {
                ICollection<Post> postsToAdd = new List<Post>();

                foreach(var postDto in importPostDtos)
                {
                    if (!IsValid(postDto))
                    {
                        resulstSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCreatedAtValid = DateTime
                                    .TryParseExact(postDto.CreatedAt,
                                    "yyyy-MM-ddTHH:mm:ss",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out DateTime createdAtParse);

                    bool isCreatorIdValid = int
                                .TryParse(postDto.CreatorId,
                                           out int creatorIdParse);

                    if(!isCreatorIdValid || !isCreatedAtValid)
                    {
                        resulstSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if(postsToAdd.Any(p=>p.Content==postDto.Content
                                      && p.CreatedAt==createdAtParse
                                      && p.CreatorId == creatorIdParse))
                    {
                        resulstSb.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    if (!dbContext.Users.Any(u => u.Id == creatorIdParse))
                    {
                        resulstSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Post post = new Post
                    {
                        Content = postDto.Content,
                        CreatedAt = createdAtParse,
                        CreatorId = creatorIdParse
                    };

                    var user = dbContext.Users
                        .AsNoTracking()
                        .FirstOrDefault(u=>u.Id == creatorIdParse);

                    postsToAdd.Add(post);
                    resulstSb.AppendLine(string.Format(SuccessfullyImportedPostEntity, user.Username, createdAtParse.ToString("yyyy-MM-ddTHH:mm:ss")));
                }

               dbContext.Posts.AddRange(postsToAdd);
                dbContext.SaveChanges();
            }

            return resulstSb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
