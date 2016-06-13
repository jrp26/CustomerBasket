using TechTalk.SpecFlow;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basket.Host.Spec
{
    [Binding]
    public sealed class BasketSteps
    {
        Product.Provider ProductProvider { get; set; }
        Price.Provider PriceProvider { get; set; }
        App.Basket Basket { get; set; }
        
        public BasketSteps()
        {
            Initilise();
        }

        private void Initilise()
        {
            Product.Model.Product prodBread = new Product.Model.Product(1, "bread");
            Product.Model.Product prodButter = new Product.Model.Product(2, "butter");
            Product.Model.Product prodMilk = new Product.Model.Product(3, "milk");

            // Initialise available products:
            ProductProvider = new Product.Provider();
            ProductProvider.Add(prodBread);
            ProductProvider.Add(prodButter);
            ProductProvider.Add(prodMilk);

            // Initialise available prices:
            PriceProvider = new Price.Provider();
            PriceProvider.AddCost(new Price.Model.Cost(prodBread.Id, 1));
            PriceProvider.AddCost(new Price.Model.Cost(prodButter.Id, 0.8));
            PriceProvider.AddCost(new Price.Model.Cost(prodMilk.Id, 1.15));

            // Intialise available offers:
            PriceProvider.AddOffer(new Price.Model.Offer("Buy 2 butter and get a Bread at 50% off", new Price.Model.Trigger(new List<Price.Model.Product>() { new Price.Model.Product(prodButter.Id, 2), new Price.Model.Product(prodBread.Id, 1) }), new Price.Model.Reward(0.5)));
            PriceProvider.AddOffer(new Price.Model.Offer("Buy 3 milk get the 4th milk for free", new Price.Model.Trigger(new List<Price.Model.Product>() { new Price.Model.Product(prodMilk.Id, 3) }), new Price.Model.Reward(1.15)));

            Basket = new App.Basket(PriceProvider);
        }

        [Given("the basket has 1 bread, 1 butter and 1 milk")]
        public void GivenIHaveEnteredOneBreadOneButterOneMilk()
        {
            Basket.Add(new App.BasketItem(ProductProvider.Find("bread").Id, 1));
            Basket.Add(new App.BasketItem(ProductProvider.Find("butter").Id, 1));
            Basket.Add(new App.BasketItem(ProductProvider.Find("milk").Id, 1));
        }

        [Given("the basket has 2 butter and 2 bread")]
        public void GivenIHaveEnteredTwoButterTwoBread()
        {
            Basket.Add(new App.BasketItem(ProductProvider.Find("butter").Id, 2));
            Basket.Add(new App.BasketItem(ProductProvider.Find("bread").Id, 2));
        }

        [Given("the basket has 4 milk")]
        public void GivenIHaveEnteredFourMilk()
        {
            Basket.Add(new App.BasketItem(ProductProvider.Find("milk").Id, 4));
        }

        [Given("the basket has 2 butter, 1 bread and 8 milk")]
        public void GivenIHaveEnteredTwoButterOneBreadEightMilk()
        {
            Basket.Add(new App.BasketItem(ProductProvider.Find("butter").Id, 2));
            Basket.Add(new App.BasketItem(ProductProvider.Find("bread").Id, 1));
            Basket.Add(new App.BasketItem(ProductProvider.Find("milk").Id, 8));
        }

        [When("I total the basket")]
        public void WhenITotalTheBasket()
        {
            Basket.CalculateTotal();
        }

        [Then("the total should be £(.*)")]
        public void ThenTheResultShouldBe(double total)
        {
            Assert.AreEqual(total, Basket.Total);
        }
    }
}
