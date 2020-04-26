namespace Common.Const
{
    public class Errors
    {
        public const string NotEmpty = "Boş bırakılamaz";

        public static string MustBeGreater(int num)
        {
            return $"{num} değerinden büyük olmalıdır";
        }
    }
}
