using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TitleGame
{
    [System.Serializable]
    public class CurrencyUIPanelSimple : MonoBehaviour
    {
        [SerializeField] CurrencyType currencyType;

        [Space]
        [SerializeField] bool initialiseOnStart = true;
        [SerializeField] bool updateOnChange = true;
        [SerializeField] bool useFormattedAmount = true;

        [Space]
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] Image icon;
       // [SerializeField] Button addButton;

        public string Text { get => text.text; set => text.text = value; }
        public Sprite Icon { get => icon.sprite; set => icon.sprite = value; }
       // public Button AddButton => addButton;

        private Currency currency;
        public Currency Currency => currency;
        
        private RectTransform rectTransformRef;
        public RectTransform RectTransform => rectTransformRef;

        private bool isInitialised;

        private void Awake()
        {
            rectTransformRef = GetComponent<RectTransform>();
            
            if(initialiseOnStart)
            {
                CurrenciesController.InvokeOrSubcrtibe(Initialise);
            }
        }

        public void Initialise()
        {
            if (isInitialised) return;

            currency = CurrenciesController.GetCurrency(currencyType);

            icon.sprite = currency.Icon;

            isInitialised = true;

            Redraw();
            Activate();
        }


        public void Redraw()
        {
            //text.text = useFormattedAmount ? currency.AmountFormatted : currency.Amount.ToString();
            this.text.text = DataController.instance.dataPlayerController.gold.ToString();
        }

        public void SetAmount(int amount, bool format = true)
        {
           // text.text = format ? CurrenciesHelper.Format(amount) : amount.ToString();
            this.text.text = DataController.instance.dataPlayerController.gold.ToString();
        }

        public void Activate()
        {
            if(updateOnChange)
            {
                //currency.OnCurrencyChanged += OnCurrencyAmountChanged;
               // this.text.text = DataController.instance.dataPlayerController.gold.ToString();
                SetTextGold();
            }
        }

        public void Disable()
        {
            if(updateOnChange)
            {
                // currency.OnCurrencyChanged -= OnCurrencyAmountChanged;
                SetTextGold();
            }
        }

        private void OnCurrencyAmountChanged(Currency currency, int amountDifference)
        {
            text.text = useFormattedAmount ? currency.AmountFormatted : currency.Amount.ToString();
        }

        public void SetTextGold()
        {
            this.text.text = DataController.instance.dataPlayerController.gold.ToString();
            DataController.instance.SaveData();
        }
    }
}