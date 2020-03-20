using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class UnitTests
    {
        [Test]
        public void SulfurasDoesNotDecreaseInQualityOrSellIn()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}
            };
            var gildedRose = new GildedRose(Items);
            
            gildedRose.UpdateQuality();

            gildedRose.Items[0].Quality.Should().Be(80);
            gildedRose.Items[0].SellIn.Should().Be(0);
            gildedRose.Items[1].Quality.Should().Be(80);
            gildedRose.Items[1].SellIn.Should().Be(-1);
        }
    }
}