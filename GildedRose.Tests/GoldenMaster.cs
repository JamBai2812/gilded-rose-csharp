using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class GoldenMasterTest
    {
        
        [Test]
        public void GoldenMaster()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                // new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            
            var originalOutput = new List<string>
            {
                "+5 Dexterity Vest - Qual 17, Sell in 7",
                "Aged Brie - Qual 4, Sell in -1",
                "Elixir of the Mongoose - Qual 4, Sell in 2",
                "Sulfuras, Hand of Ragnaros - Qual 80, Sell in 0",
                "Sulfuras, Hand of Ragnaros - Qual 80, Sell in -1",
                "Backstage passes to a TAFKAL80ETC concert - Qual 23, Sell in 12",
                "Backstage passes to a TAFKAL80ETC concert - Qual 50, Sell in 7",
                "Backstage passes to a TAFKAL80ETC concert - Qual 50, Sell in 2"
            };
            var gildedRose = new GildedRose(Items);
            var output = new List<string>();

            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            foreach (var item in Items)
            {
                output.Add($"{item.Name} - Qual {item.Quality}, Sell in {item.SellIn}");
            }

            output.Should().Equal(originalOutput);
        }
    }
}