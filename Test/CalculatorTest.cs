using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class CalculatorTest
    {
        [Fact]
        public void AddTest()
        {

            #region Equal, NotEqual Kullanım Örnekleri
            ////İlk parametre Beklenen değer, ikinci parametre gelen değerdir.
            //Arrange - Hazırlık evresidir.
            int a = 5;
            int b = 20;
            var calculator = new Calculator();

            //Act - Test edilecek methodun çağırıldığı evredir.
            var total = calculator.Add(a, b);

            //Assert - Doğrulama evresidir. Testten dönen sonuç doğru mu? kontrol edilir.
            Assert.Equal<int>(25, total);
            Assert.NotEqual<int>(26, total);
            #endregion

            #region Contains ve DoesNotContains Kullanım Örnekleri
            //1. argüman, 2. argüman içerisinde geçiyor mu kontrol sağlıyor.
            Assert.Contains("Serdar", "Ömer Serdar ŞERİFOĞLU");

            //Contains'in tam tersi olarak çalışır.
            Assert.DoesNotContain("Serdar", "Ömer Ser2dar ŞERİFOĞLU");


            var names = new List<string>() { "Ömer", "Serdar", "Şerifoğlu" };
            Assert.Contains(names, x => x == "Serdar");
            #endregion

            #region True, False Kullanım Örnekleri
            //İçindeki şartın beklentisini belirlemeye yarıyor.
            Assert.True(2 < 5);
            Assert.False(2 > 5);
            Assert.True("".GetType() == typeof(string));
            #endregion

            #region Matches, DoesNotMatch Kullanım Örnekleri
            ////Regex kullanılmasını sağlıyor

            var regEx = "^cat";
            Assert.Matches(regEx, "cat dog");
            Assert.DoesNotMatch(regEx, "2 cat dog");

            #endregion

            #region StartsWith, EndsWith Kullanım Örnekleri

            Assert.StartsWith("cat", "cat dog");
            Assert.EndsWith("dog", "cat dog");

            #endregion

            #region Empty, NotEmpty Kullanım Örnekleri

            Assert.Empty(new List<string>() { });
            Assert.NotEmpty(new List<string>() { "serdar" });

            #endregion

            #region InRange, NotInRange Kullanım Örnekleri
            ////150 değeri 0 ile 1000 arasındaysa InRange methodu true döner. NotInRange tam tersi olarak çalışır.
            Assert.InRange(150, 0, 1000);
            Assert.NotInRange(1500, 0, 1000);

            #endregion

            #region Single Kullanım Örnekleri
            ////Verilen listede bir eleman varsa true, birden fazla eleman varsa false döner.

            Assert.Single(new List<string>() { "Serdar" });
            Assert.Single(new List<string>() { "Serdar", "Ömer", "Serdar" }, x => x == "Ömer");
            ////Verilen listeli tip zorunluda bu şekilde yapabiliriz
            Assert.Single<int>(new List<int>() { 1 });

            #endregion

            #region IsType, IsNotType Kullanım Örnekleri
            ////Parametre olarak geçilen objenin tipi verilen tip ile uyumsuzsa IsType false döner, IsNotType'ta tersi şeklinde çalışır.
            Assert.IsType<string>("serdar");
            Assert.IsNotType<int>("serdar");

            #endregion

            #region IsAssignableFrom Kullanım Örnekleri
            ////IsAssignableFrom referans olarak alınıp alanımayacağını kontrol ediyor.
            Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());
            Assert.IsAssignableFrom<Object>("Serdar");
            #endregion

            #region Null, NotNull Kullanım Örnekleri
            ////Null Gönderilen obje null ise true döner, NotNull tam tersi olarak çalışır.
            string valueNull = null;
            string valueNotNull = "";

            Assert.Null(valueNull);
            Assert.NotNull(valueNotNull);

            #endregion



        }

        [Theory]
        [InlineData(2, 5, 7)]
        [InlineData(2, 15, 17)]
        public void AddTestWithArguments(int a, int b, int expectedTotal)
        {
            var calculator = new Calculator();
            var actualTotal = calculator.Add(a, b);

            Assert.Equal<int>(expectedTotal, actualTotal);
        }
    }
}
