namespace MusicHub.Validators
{
    public static class ModelValidators
    {
        public static class SongValidator
        {
            public const int songNameLength = 20;
        }

        public static class AlbumValidator
        {
            public const int albumNameLength = 40;
        }

        public static class PerformerValidator
        {
            public const int performerFisrtNameLength = 20;
            public const int performerLastNameLength = 20;
        }

        public static class ProducerValidator
        {
            public const int producerNameLength = 30;
            public const int producerPseudonymLength = 120;
            public const int producerPhoneNumberLength = 16;

        }

        public static class WriterValidator
        {
            public const int writerNameLength = 30;
            public const int writerPseudonymLength = 120;
        }
    }
}
