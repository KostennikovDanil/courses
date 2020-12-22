using System;
using System.Threading;

namespace OOP
{
    class Program
    {
        class Courier
        {
            public bool IsFree;
        }
        class CourierCollection
        {
            private Courier[] collection;
            public int Length { get; private set; }
            public CourierCollection(Courier[] collection)
            {
                this.collection = collection;
                Length = collection.Length;
            }
            public Courier this[int index]
            {
                get
                {
                    if (index >= 0 && index < collection.Length)
                        return collection[index];
                    else
                        return null;
                }
                private set
                {
                    if (index >= 0 && index < collection.Length)
                        collection[index] = value;
                }
            }
            public void Add(Courier courier)
            {
                Courier[] tmpCollection;
                tmpCollection = collection;

                collection = null;
                collection = new Courier[tmpCollection.Length + 1];
                for (int i = 0; i < tmpCollection.Length; i++) 
                {
                    collection[i] = tmpCollection[i];
                }
                collection[tmpCollection.Length] = courier;
                Length = collection.Length;
                tmpCollection = null;
            }
        }
        abstract class Delivery
        {
            public string Address;
            public abstract void MakeDelivery(CourierCollection collection = null);
            public abstract void TakeItem(int index, CourierCollection collection = null);

        }

        class HomeDelivery : Delivery
        {

            private int FindFreeCourier(CourierCollection collection)
            {

                for (int i = 0; i < collection.Length; i++) 
                {
                    if (collection[i].IsFree)
                    {
                        //collection[i].IsFree = false;
                        return i;
                    }
                }
                return -1;
            }

            public override void MakeDelivery(CourierCollection collection)
            {
                int index = FindFreeCourier(collection);
                if(index == -1)
                {
                    Console.WriteLine("Все курьеры заняты, попробуйте сделать заказ позже");
                }
                else
                {
                    collection[index].IsFree = false;
                }
            }

            public override void TakeItem(int index, CourierCollection collection)
            {
                collection[index].IsFree = true;
            }
        }

        static class PickPoint
        {
            public static int MaxAmoutnOfItems = 256;
            public static int AmountOfItemsOnPickPoint = 0;
            public static int[] ItemCycleOnPickPoint = new int[256];  // how long the item has been in pick point
            static void Filling()
            {
                for (int i=0;i<ItemCycleOnPickPoint.Length;i++)
                {
                    ItemCycleOnPickPoint[i] = 0;
                }
            }
        }

        class PickPointDelivery : Delivery
        {

            
            void FindFreePlace()
            {
                if (PickPoint.AmountOfItemsOnPickPoint < PickPoint.MaxAmoutnOfItems)
                {
                    PickPoint.AmountOfItemsOnPickPoint++;
                    for (int i = 0; i < PickPoint.ItemCycleOnPickPoint.Length; i++)
                    {
                        if (PickPoint.ItemCycleOnPickPoint[i] == 0)
                            PickPoint.ItemCycleOnPickPoint[i] = 1;
                    }
                }
                else
                {
                    for (int i = 0; i < PickPoint.ItemCycleOnPickPoint.Length; i++)
                    {
                        if (PickPoint.ItemCycleOnPickPoint[i] >= 15)
                            PickPoint.ItemCycleOnPickPoint[i] = 0;
                    }
                }
            }

            public override void MakeDelivery(CourierCollection collection = null)
            {
                FindFreePlace();
            }
            public override void TakeItem(int index, CourierCollection collection = null)
            {
                PickPoint.ItemCycleOnPickPoint[index] = 0;
            }


        }

        class ShopDelivery : Delivery
        {
            public override void MakeDelivery(CourierCollection collection = null)
            {


            }
            public override void TakeItem(int index, CourierCollection collection = null)
            {
                PickPoint.ItemCycleOnPickPoint[index] = 0;
            }
        }

        class Order<TDelivery> where TDelivery : Delivery
        {
            public TDelivery Delivery;

            public int Number;

            public string Description;

            public void DisplayAddress()
            {
                Console.WriteLine(Delivery.Address);
            }
        }

        static void Main(string[] args)
        {
            
            var array = new Courier[]
            {
                new Courier {IsFree = true},
                new Courier {IsFree = true},
                new Courier {IsFree = true},

            };

            CourierCollection collection = new CourierCollection(array);

            var order = new Order<ShopDelivery>();
            order.Delivery.MakeDelivery();
            //
            //
            //
        }
    }
}
