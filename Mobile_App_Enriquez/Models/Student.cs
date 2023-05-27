using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mobile_App_Enriquez.App;
using Firebase.Database.Query;
using Firebase.Storage;
using Microsoft.Maui.ApplicationModel.Communication;
using Firebase.Database;
using System.Collections.ObjectModel;

namespace Mobile_App_Enriquez.Models
{
    public class Student
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagae_1_link { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string image5 { get; set; }
        public string image6 { get; set; }
        public string image7 { get; set; }

        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string ProductPrice { get; set; }





        public async Task<string> UploadImage(Stream img, string proname, string filename )
        {
            try
            {
                var image = await App.firebaseStorage
                    .Child($"Images/{proname}/{filename}")
                    .PutAsync(img);
                return image;
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
        public async Task<bool> addDesc(string imglink,
                                        string img1,
                                        string img2,
                                        string img3,
                                        string img4,
                                        string img5,
                                        string img6,
                                        string ProdName,
                                        string ProdDesc,
                                        string ProdPrice) 
        {
            try
            {
                var evaluateEmail = (await client.Child("Products")
                .OnceAsync<Student>())
                     .FirstOrDefault(a => a.Object.Imagae_1_link == imglink);

                if (evaluateEmail == null)
                {
                    var admin = new Student()
                    {
                       
                        image1 = img1,
                        image2 = img2,
                        image3 = img3,
                        image4 = img4,
                        image5 = img5,
                        image6 = img6,
                        Imagae_1_link = imglink,
                        ProductName = ProdName,
                        ProductDesc = ProdDesc,
                        ProductPrice = ProdPrice
                    };
                    await client
                       .Child("Products")
                       .PostAsync(admin);
                    client.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Student>> GetAllUsers()
        {

            return (await client
                .Child("Products")
                .OnceAsync<Student>()).Select(item => new Student
                {
                    Imagae_1_link = item.Object.Imagae_1_link,
                    ProductName = item.Object.ProductName,
                    ProductDesc = item.Object.ProductDesc,
                    ProductPrice = item.Object.ProductPrice,

                }).ToList();
        }

        public ObservableCollection<Student> GetEmployeesList()
        {
            var employeelist = client
                 .Child("Products")
                .AsObservable<Student>()
                .AsObservableCollection();
            return employeelist;
        }



            public async Task<bool> Save(FileResult maninimg,
                                     FileResult img1,
                                     FileResult img2,
                                     FileResult img3,
                                     FileResult img4,
                                     FileResult img5,
                                     FileResult img6,
                                     string productname,
                                     string productDescript,
                                     string productprice)
        {
            var _mainimg = await UploadImage(await maninimg.OpenReadAsync(),                                              
                                             "ProductImg",
                                             $"_mainimg.png") ;

            var _mainimg1 = await UploadImage(await img1.OpenReadAsync(),
                                            "ProductImg",
                                            $"1.png");
            var _mainimg2 = await UploadImage(await img2.OpenReadAsync(),
                                            "ProductImg",
                                            $"2.png");
            var _mainimg3 = await UploadImage(await img3.OpenReadAsync(),
                                            "ProductImg",
                                            $"3.png");
            var _mainimg4 = await UploadImage(await img4.OpenReadAsync(),
                                            "ProductImg",
                                            $"4.png");
            var _mainimg5 = await UploadImage(await img5.OpenReadAsync(),
                                            "ProductImg",
                                            $"5.png");
            var _mainimg6 = await UploadImage(await img6.OpenReadAsync(),
                                            "ProductImg",
                                            $"6.png");

            var _main1 = await addDesc(_mainimg,
                                       _mainimg1,
                                       _mainimg2,
                                       _mainimg3,
                                       _mainimg4,
                                       _mainimg5,
                                       _mainimg6,
                                       productname,
                                       productDescript,
                                       productprice);

            return true;
        }
    }   
}
