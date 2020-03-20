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

        [Test]
        public void AgedBrieShouldIncreaseInQualityUntil50()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 50},
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 38},
                new Item {Name = "Aged Brie", SellIn = -3, Quality = 10}
            };
            var gildedRose = new GildedRose(Items);
            
            gildedRose.UpdateQuality();
            
            gildedRose.Items[0].Quality.Should().Be(50);
            gildedRose.Items[1].Quality.Should().Be(39);
            gildedRose.Items[2].Quality.Should().Be(12);
        }
        
        [Test]
        public void BackstagePassesShouldIncreaseByOneWhenSellInIsOverTen()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10},
                
            };
            var gildedRose = new GildedRose(Items);
            
            gildedRose.UpdateQuality();
            
            gildedRose.Items[0].Quality.Should().Be(11);
            gildedRose.Items[1].Quality.Should().Be(12);
            gildedRose.Items[2].Quality.Should().Be(13);
            gildedRose.Items[3].Quality.Should().Be(0);
        }
    }
}