namespace SocialNetwork.Common
{

    public static class SocialNetworkValidations
    {
       // public const string dateFormat = "yyyy-MM-ddТHH:mm:ss"; // From Word File
        public const string dateFormat = "yyyy-MM-ddTHH:mm:ss";
        public static class UserSocialNetworkValidations
        {
            public const int userUserNameMinLength = 4;
            public const int userUserNameMaxLength = 20;

            public const int userEmailMinLength = 8;
            public const int userEmailMaxLength = 60;

            public const int userPasswordLength = 6;
        }

        public static class ConversationSocialNetworkValidations
        {

            public const int conversationTitleMinLength = 2;
            public const int conversationTitleMaxLength = 30;
        }

        public static class PostSocialNetworkValidations
        {
            public const int postContentMinLength = 5;
            public const int postContentMaxLength = 300;
        }

        public static class MessageSocialNetworkValidations
        {
            public const int messageContentMinLength = 1;
            public const int messageContentMaxLength = 200;
        }
    }
}
