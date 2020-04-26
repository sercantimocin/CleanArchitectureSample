namespace Common.Const
{
    public class Errors
    {
        public const string NotEmpty = "Boş bırakılamaz";
        public const string InsufficientStockCount = "Yetersiz stok sayısı";
        public const string OperationFailed = "İşlem gerçekleştirilemedi";

        public static string MustBeGreater(int num)
        {
            return $"{num} değerinden büyük olmalıdır";
        }


    }
}
