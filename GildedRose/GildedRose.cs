﻿using System.Collections.Generic;

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
                    
                    case "Backstage passes to a TAFKAL80ETC concert" :

                        break;

                    default:

                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                item.Quality--;
                            }
                        }
                        else
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality++;

                                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                                {
                                    if (item.SellIn < 11)
                                    {
                                        if (item.Quality < 50)
                                        {
                                            item.Quality++;
                                        }
                                    }

                                    if (item.SellIn < 6)
                                    {
                                        if (item.Quality < 50)
                                        {
                                            item.Quality++;
                                        }
                                    }
                                }
                            }
                        }

                        item.SellIn--;


                        if (item.SellIn < 0)
                        {
                            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (item.Quality > 0)
                                {
                                    item.Quality--;
                                }
                            }
                            else
                            {
                                item.Quality = 0;
                            }
                        }

                        break;
                }
            }
        }
    }
}