namespace OnlineMenu.Common
{
    public static class EntityValidationConstants
    {
        public static class FoodCategoryValidation
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
        }

        public static class DrinkCategoryValidation
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class FoodValidation
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int ImageUrlMinLength = 10;
            public const int ImageUrlMaxLength = 2048;

            public const int WeightMinValue = 1;
            public const int WeightMaxValue = 3000;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "3000";

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 300;
        }

        public static class DrinkValidation
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int ImageUrlMinLength = 10;
            public const int ImageUrlMaxLength = 2048;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "10000";

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 300;

            public const int MillilitersMinValue = 1;
            public const int MillilitersMaxValue = 3000;
        }

        public static class ManagerValidation
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;

            public const int PhoneNumberMinLength = 8;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
