﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalSi.Tablas;

namespace final
{
    class Program
    {
        static void Main(string[] args)
        {
            Program enterprise = new Program();
            enterprise.Controller();


        }

        private void Controller()
        {
            int menu;


            using (var db = new MyContext())
            {

                menu = SelectOption();

                do
                {

                    switch (menu)
                    {
                        case 1:
                            db.product.Add(Product());
                            db.SaveChanges();
                            break;
                        case 2:
                            db.customer.Add(Client());
                            db.SaveChanges();
                            break;
                        case 3:

                            db.manufacturer.Add(Manufacturer());
                            db.SaveChanges();
                            break;
                        case 4:
                            ShowProducts();
                            break;
                        case 5:
                            ShowCustomers();
                            break;
                        case 6:
                            ShowManufacturers();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Key error, introduce 1/2/3/4/5/6/7");
                            break;
                    }
                    menu = SelectOption();
                } while (menu != 7);

            }

        }
        private int SelectOption()
        {
            int menu = 0;

            Console.WriteLine("Select: ");
            Console.WriteLine("1) Add product");
            Console.WriteLine("2) Add client");
            Console.WriteLine("3) Add manufacturer");
            Console.WriteLine("4) Show product");
            Console.WriteLine("5) Show customers");
            Console.WriteLine("6) Show manufacturers"
                );
            Console.WriteLine("7) Exit");

            try
            {
                menu = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Key error, introduce 1/2/3/4/5/6/7");
                System.Threading.Thread.Sleep(1200);
                Console.Clear();
                SelectOption();
            }
            Console.Clear();

            return menu;
        }
        private static products1 Product()
        {
            String titleV = "a";
            int manufacturerV = 0;
            int priceV = 0;

            try
            {
                Console.WriteLine("Introduce the product title");
                titleV = Console.ReadLine();
                Console.WriteLine("Introduce the product manufacturer");
                manufacturerV = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduce the product price");
                priceV = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Incorrect value");
                System.Threading.Thread.Sleep(1200);
                Console.Clear();
                Product();
            }
            Console.Clear();
            Console.WriteLine("Added succesfully");
            System.Threading.Thread.Sleep(600);
            Console.Clear();

            return new products1
            {
                title = titleV,
                manufacturer = manufacturerV,
                price = (decimal)priceV
            };
        }
        private static customers1 Client()
        {
            String nifV = "";
            String nameV = "";
            String surnameV = "";
            DateTime birth_dateV = Convert.ToDateTime("01/01/2000");
            String genderV = "";
            String emailV = "";
            String phoneV;
            String credit_cardV;
            Boolean date = false;

            Console.WriteLine("Introduce the client NIF");
            nifV = Console.ReadLine();
            Console.WriteLine("Introduce the client name");
            nameV = Console.ReadLine();
            Console.WriteLine("Introduce the client surname");
            surnameV = Console.ReadLine();
            Console.WriteLine("Introduce the client birth_date");
            try
            {
                birth_dateV = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Incorrect date");
                System.Threading.Thread.Sleep(1200);
                Console.Clear();
                Client();
            }
            Console.WriteLine("Introduce the client gender");
            genderV = Console.ReadLine();
            Console.WriteLine("Introduce the client email");
            emailV = Console.ReadLine();
            Console.WriteLine("Introduce the client phone");
            phoneV = Console.ReadLine();
            Console.WriteLine("Introduce the client credit_card");
            credit_cardV = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Added succesfully");
            System.Threading.Thread.Sleep(600);
            Console.Clear();

            return new customers1
            {
                nif = nifV,
                name = nameV,
                surname = surnameV,
                birth_date = birth_dateV,
                gender = genderV,
                email = emailV,
                phone_number = phoneV,
                credit_card = credit_cardV
            };
        }
        private static manufacturers1 Manufacturer()
        {
            String nameV = " ";
            String municipalityV = " ";

            Console.WriteLine("Introduce the manufacturer name");
            nameV = Console.ReadLine();
            Console.WriteLine("Introduce the manufacturer municipality");
            municipalityV = Console.ReadLine();
            Console.WriteLine("Added succesfully");
            System.Threading.Thread.Sleep(600);
            Console.Clear();

            return new manufacturers1
            {
                name = nameV,
                municipality = municipalityV
            };
        }
        private void ShowProducts()
        {
            using (var db = new MyContext())
            {
                var query = from product in db.product
                            select product;

                foreach (products1 product in query)

                {

                    Console.Write(product.id_product + " " + product.title + " " + product.manufacturer + " " + product.price);

                    Console.WriteLine();

                }

                Console.Write("Press any key to return menu: ");
                Console.ReadKey();

                Console.Clear();

            }
        }
        private void ShowCustomers()
        {
            using (var db = new MyContext())
            {
                var query = from customers in db.customer
                            select customers;

                foreach (customers1 customers in query)

                {

                    Console.Write(customers.id_customers + " " + customers.nif + " " + customers.name + " " + customers.surname +
                        " " + customers.birth_date + " " + customers.gender + " " + customers.email + " " + customers.phone_number
                        + " " + customers.credit_card);

                    Console.WriteLine();

                }

                Console.Write("Press any key to return menu: ");
                Console.ReadKey();

                Console.Clear();

            }
        }
        private void ShowManufacturers()
        {
            using (var db = new MyContext())
            {
                var query = from manufacturers in db.manufacturer
                            select manufacturers;

                foreach (manufacturers1 manufacturers in query)

                {

                    Console.Write(manufacturers.id_manufacturer + " " + manufacturers.name + " " + manufacturers.municipality);

                    Console.WriteLine();

                }

                Console.Write("Press any key to return menu: ");
                Console.ReadKey();

                Console.Clear();

            }
        }
    }
}
