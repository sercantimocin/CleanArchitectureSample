namespace Common.Static
{
    public class Errors
    {
        public static string NotEmpty(string fieldName)
        {
            return $"{fieldName} boş bırakılamaz";
        }

        public static string NotInRange(string fieldName)
        {
            return $"{fieldName} değer aralığının dışındadır";
        }

        public static string NotInRange(string fieldName, int min, int max)
        {
            return $"{fieldName},{min}-{max} aralığında  olmalıdır";
        }

        public static string NotValid(string fieldName)
        {
            return $"{fieldName} değeri yanlış yada hatalıdır";
        }

        public static string MustBeGreater(string fieldName, int num)
        {
            return $"{fieldName}, {num} değerinden büyük olmalıdır";
        }

        public static string MustBeEqual(string fieldName, int num)
        {
            return $"{fieldName}, {num} değerine eşit olmalıdır";
        }

        public static string ItemCount(string fieldName, int num)
        {
            return $"{fieldName}, {num} elemana sahip olmalıdır";
        }

        public static string MustBeUnique(string fieldName)
        {
            return $"{fieldName}, tekrar eden elemana sahip olmamalıdır";
        }
    }
}
