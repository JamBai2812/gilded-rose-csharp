using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":

                        break;

                    case "Aged Brie":

                        item.SellIn--;

                        if (item.Quality < 50)
                            item.Quality++;

                        if (item.SellIn < 0)
                            item.Quality++;

                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":

                        if (item.SellIn > 10)
                            item.Quality++;
                        else if (item.SellIn > 5)
                            item.Quality += 2;
                        else if (item.SellIn > -1)
                            item.Quality += 3;
                        else if (item.SellIn < 0)
                            item.Quality = 0;

                        item.SellIn--;
                        break;

                    default:

                        if (item.SellIn >= 0 && item.Quality > 0)
                        {
                            item.Quality--;
                        }
                        else if (item.SellIn < 0 && item.Quality > 1)
                        {
                            item.Quality -= 2;
                        }
                        else
                        {
                            item.Quality = 0;
                        }

                        item.SellIn--;

                        break;
                }
            }
        }
    }
}