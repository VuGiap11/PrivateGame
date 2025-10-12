using NTPackage.UI;
using TitleGame;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace IAP
{
    public class IAPManager : MonoBehaviour, IStoreListener
    {
        private IStoreController storeController;
        private IExtensionProvider extensionProvider;
        // Thiết lập các sản phẩm đã đăng ký
        //public string[] productIds = new string[] { Contans.AdsClaw100, Contans.RemoveADS }; // Sửa theo sản phẩm của bạn
        public List<string> productIds = new List<string>();
        public static IAPManager Instance;

        public Dictionary<string, Action> BuySuccessAct;
        public Dictionary<string, Action> BuyFailAct;

        // public string productId = "com.example.product"; // Sửa theo sản phẩm của bạn
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        void Start()
        {
            // Init();

        }
        public void Init()
        {
            this.BuySuccessAct = new Dictionary<string, Action>();
            this.BuyFailAct = new Dictionary<string, Action>();
            if (DataAssets.instance.IapDataCfs.iapDataCfs.Count <= 0) return;
            for (int i = 0; i < DataAssets.instance.IapDataCfs.iapDataCfs.Count; i++)
            {
                this.productIds.Add(DataAssets.instance.IapDataCfs.iapDataCfs[i].Id);
            }
            this.productIds.Add(Contans.RemoveADS);
            this.productIds.Add(Contans.StarterPack);
            if (storeController == null)
            {
                var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
                foreach (var productId in productIds)
                {
                    //var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
                    builder.AddProduct(productId, ProductType.Consumable);  // Loại sản phẩm của bạn (Consumable, NonConsumable, Subscription)
                }
                UnityPurchasing.Initialize(this, builder);
            }
        }

        public void InitActionSuccess(string id, Action action)
        {
            if (!this.BuySuccessAct.ContainsKey(id))
            {
                this.BuySuccessAct.Add(id, action);
            }
            // this.BuySuccessAct.Add(id, action);
        }
        public void InitActionFail(string id, Action action)
        {
            if (!this.BuyFailAct.ContainsKey(id))
            {
                this.BuyFailAct.Add(id, action);
            }
            // this.BuyFailAct.Add(id, action);
        }
        // Xử lý sự kiện khi giao dịch thành công
        public void OnBuySuccess(Product product)
        {
            Debug.Log("Mua thành công: " + product.definition.id);
            this.BuySuccessAct[product.definition.id]?.Invoke();
            PopupManager.Instance.OnUI(PopupCode.ResultIAP);
            // Thực hiện hành động sau khi mua thành công, ví dụ như mở khóa tính năng
        }

        // Xử lý sự kiện khi giao dịch thất bại
        public void OnBuyFail(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log("Mua thất bại: " + failureReason);
            this.BuyFailAct[product.definition.id]?.Invoke();
            // Xử lý khi giao dịch thất bại (ví dụ: thông báo lỗi cho người dùng)
        }

        // Được gọi khi người dùng nhấn nút mua hàng
        public void OnPurchaseButtonClick(string productId)
        {
            if (storeController != null)
            {
                Product product = storeController.products.WithID(productId);
                if (product != null && product.availableToPurchase)
                {
                    storeController.InitiatePurchase(product);
                }
                else
                {
                    Debug.LogError("product" + productId);
                    Debug.LogError("Sản phẩm không thể mua được.");
                }
            }
        }

        // Implement các phương thức IStoreListener còn lại
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            storeController = controller;
            extensionProvider = extensions;
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.LogError("Khởi tạo IAP thất bại: " + error.ToString());
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            OnBuyFail(product, failureReason);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            Product product = purchaseEvent.purchasedProduct;
            OnBuySuccess(product);
            return PurchaseProcessingResult.Complete;
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            throw new System.NotImplementedException();
        }


        public void FetchPrice(string productId, Action<float> onPriceFetched)
        {
            if (storeController != null)
            {
                Product product = storeController.products.WithID(productId);
                if (product != null)
                {
                    Debug.Log($"Price for {productId}: {product.metadata.localizedPriceString}");
                    float price = (float)product.metadata.localizedPrice;
                    Debug.Log($"Price for {productId}: {price}");
                    onPriceFetched?.Invoke(price); // Gửi giá trị về class khác
                }
                else
                {
                    Debug.LogWarning($"Product {productId} not found.");
                    onPriceFetched?.Invoke(-1f);
                }
            }
            else
            {
                InitializePurchasing();
                onPriceFetched?.Invoke(-1f);
            }
        }
        private void InitializePurchasing()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct("your_product_id", ProductType.Consumable);

            UnityPurchasing.Initialize(this, builder);  
        }
    }

}