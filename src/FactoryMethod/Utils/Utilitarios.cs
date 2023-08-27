namespace FactoryMethod.Utils
{
    public static class Utilitarios
    {
        public static decimal AplicarTaxa(decimal valor, int taxa)
        {
            decimal acrescimo = valor * (Convert.ToDecimal(taxa) / 100);
            decimal transactionAmount = valor + acrescimo;
            return transactionAmount;
        }
    }
}
