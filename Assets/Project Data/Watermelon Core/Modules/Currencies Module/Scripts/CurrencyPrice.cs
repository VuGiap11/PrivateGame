using UnityEngine;

namespace TitleGame
{
    [System.Serializable]
    public class CurrencyPrice
    {
        [SerializeField] CurrencyType currencyType;
        public CurrencyType CurrencyType => currencyType;

        [SerializeField] int price;
        public int Price => price;

        public Currency Currency => CurrenciesController.GetCurrency(currencyType);
        public string FormattedPrice => CurrenciesHelper.Format(price);

        public CurrencyPrice()
        {

        }

        public CurrencyPrice(CurrencyType currencyType, int price)
        {
            this.currencyType = currencyType;
            this.price = price;
        }

        public bool EnoughMoneyOnBalance()
        {
            //return CurrenciesController.HasAmount(currencyType, price);
            return CurrenciesController.HasAmount(price);
        }

        public void SubstractFromBalance()
        {
            //CurrenciesController.Substract(currencyType, price);
            CurrenciesController.Substract(price);
        }
    }
}
