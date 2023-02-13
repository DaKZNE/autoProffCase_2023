namespace AutoPROFFTestProject
{
    [TestClass]
    public class UnitTest_Excercise1_1
    {

        #region Exercise 1.1
        [TestMethod]
        public void Test_CreateBooks()
        {
            //Arrange
            List<string> bookAuthor1 = new List<string>()
            {
                "Brian Jensen"
            };
            string title1 = "Texts from Denmark";
            string publisher1 = "Gyldendal";
            int published1 =  2001;
            int numberOfPages1 = 253;


            List<string> bookAuthor2 = new List<string>()
            {
                "Peter Jensen",
                "Hans Andersen"
            };
            string title2 = "Stories from abroad";
            string publisher2 = "Stories from abroad";
            int published2 = 2012;
            int numberOfPages2 = 156;


            //Act
            Book book1 = new Book(bookAuthor1, title1, publisher1, published1, numberOfPages1);
            Book book2 = new Book(bookAuthor2, title2, publisher2, published2, numberOfPages2);


            //Assert 
            Assert.AreEqual(title1, book1.Title, "Title constructor for book 1 didn't work as intended");
            Assert.AreEqual(publisher1, book1.Publisher, "Publisher constructor for book 1 didn't work as intended");
            Assert.AreEqual(published1, book1.PublicationYear, "Year constructor for book 1 didn't work as intended");
            Assert.AreEqual(numberOfPages1, book1.NumberOfPages, "Year constructor for book 1 didn't work as intended");

            Assert.AreEqual(title2, book2.Title, "Title constructor for book 2 didn't work as intended");
            Assert.AreEqual(publisher2, book2.Publisher, "Publisher constructor for book 2 didn't work as intended");
            Assert.AreEqual(published2, book2.PublicationYear, "Year constructor for book 2 didn't work as intended");
            Assert.AreEqual(numberOfPages2, book2.NumberOfPages, "Year constructor for book 2 didn't work as intended");



        }

        [TestMethod]
        public void Test_ReadBooks()
        {
            //Arrange
            List<string> bookAuthor1 = new List<string>()
            {
                "Brian Jensen"
            };
            string title1 = "Texts from Denmark";
            string publisher1 = "Gyldendal";
            int published1 = 2001;
            int numberOfPages1 = 253;


            List<string> bookAuthor2 = new List<string>()
            {
                "Peter Jensen",
                "Hans Andersen"
            };
            string title2 = "Stories from abroad";
            string publisher2 = "Borgen";
            int published2 = 2012;
            int numberOfPages2 = 156;

            //Going with the assumption that all lines have linkebreaks as data seperators as I see no other way to seperate data into individual key-value data in the time given.
            string bookString = "Book:\n" +
                "\nAuthor: Brian Jensen" +
                "\nTitle: Texts from Denmark" +
                "\nPublisher: Gyldendal" +
                "\nPublished: 2001" +
                "\nNumberOfPages: 253" +
                "\nBook:" +
                "\nAuthor: Peter Jensen" +
                "\nAuthor: Hans Andersen" +
                "\nTitle: Stories from abroad" +
                "\nPublisher: Borgen" +
                "\nPublished: 2012" +
                "\nNumberOfPages: 156";
            
            //Act
            Book book = new Book();
            List<Book> bookList = book.ReadBooks(bookString);

            //Assert 
            Assert.AreEqual(title1, bookList[0].Title, "Title constructor for book 1 didn't work as intended");
            Assert.AreEqual(publisher1, bookList[0].Publisher, "Publisher constructor for book 1 didn't work as intended");
            Assert.AreEqual(published1, bookList[0].PublicationYear, "Year constructor for book 1 didn't work as intended");
            Assert.AreEqual(numberOfPages1, bookList[0].NumberOfPages, "Year constructor for book 1 didn't work as intended");

            Assert.AreEqual(title2, bookList[1].Title, "Title constructor for book 2 didn't work as intended");
            Assert.AreEqual(publisher2, bookList[1].Publisher, "Publisher constructor for book 2 didn't work as intended");
            Assert.AreEqual(published2, bookList[1].PublicationYear, "Year constructor for book 2 didn't work as intended");
            Assert.AreEqual(numberOfPages2, bookList[1].NumberOfPages, "Year constructor for book 2 didn't work as intended");

            

        }
        #endregion

        #region Exercise 1.2
        [TestMethod]
        public void Test_SearchBooks()
        {
            //Arrange
            List<string> bookAuthor1 = new List<string>()
            {
                "Brian Jensen"
            };
            string title1 = "Texts from Denmark";
            string publisher1 = "Gyldendal";
            int published1 = 2001;
            int numberOfPages1 = 253;


            List<string> bookAuthor2 = new List<string>()
            {
                "Peter Jensen",
                "Hans Andersen"
            };
            string title2 = "Stories from abroad";
            string publisher2 = "Borgen";
            int published2 = 2012;
            int numberOfPages2 = 156;

            Book book1 = new Book(bookAuthor1, title1, publisher1, published1, numberOfPages1);
            Book book2 = new Book(bookAuthor2, title2, publisher2, published2, numberOfPages2);

            Shelf libary = new Shelf(1,new List<ShelfSlot>()
            {
                
                new ShelfSlot(book1, 4832), new ShelfSlot(book2, 8945)
            });

            //Act
            Book book = new Book();

            //List<Book> bookResult1 = libary.FindBooks("*20*");

            List<ShelfSlot> bookResult2 = libary.FindBooks("*20* & *Peter*");

            //Assert
            //Assert.AreEqual((int)bookResult1.Count, 2, "Find books didn't find the correct amount of books. Expected amount is 2");
            Assert.AreEqual(bookResult2.Count, 1, "Find books didn't find the correct amount of books. Expected amount is 1");
            //Assert.AreEqual(((Book)bookResult1[0]).Title, title1, "Could not find the title in the returned data of search 1");
            Assert.AreEqual(bookResult2[0].book.Title, title2, "Could not find the title in the returned data of search 2");


        }

        #endregion


        #region Exercise 1.3
        [TestMethod]
        public void Find_LibaryBooks()
        {
            //Arange
            Book book1 = new Book(new List<string>() { "Sarah Blædel"}, "Elnis død", "Politikens Forlag", 2022, 336);
            Book book2 = new Book(new List<string>() { "Tine Høeg" }, "Sult", "Gutkind", 2022, 430);
            Book book3 = new Book(new List<string>() { "Matt Haig" }, "The Midnight Libary", "Main", 2021, 304);
            Book book4 = new Book(new List<string>() { "Jón Kalman Stefánsson" }, "Dit fravær er mørke", "Batzer & Co.", 2022, 576);
            Book book5 = new Book(new List<string>() { "Paru Itagaki" }, "Beastars, Vol1", "Viz Media.", 2019, 208);


            Shelf bookShelf1 = new Shelf(46, new List<ShelfSlot>()
            {
                new ShelfSlot(book5, 38), 
                new ShelfSlot(book3, 85)
            });
            Shelf bookShelf2 = new Shelf(33, new List<ShelfSlot>()
            {
                new ShelfSlot(book1, 98),
                new ShelfSlot(book2, 222),
                new ShelfSlot(book4, 923)
            });

            Libary testLibary = new Libary(new List<Shelf>() { bookShelf1, bookShelf2 });


            //Act
            autoProffCase.Index result1 = testLibary.FindBooks("*20* & *Tine*");
            autoProffCase.Index result2 = testLibary.FindBooks("*Beastars*");

            //Assert
            Assert.AreEqual(result1.shelveIdList.Contains(33), true, "The search did not return the right shelf");
            Assert.AreEqual(result1.PlacedBooks.Count, 1, "Did not find all books in result 1");
            Assert.AreEqual(result2.PlacedBooks[0].book.Title, book5.Title, "Book 5 was not found");

        }

        [TestMethod]
        public void Insert_LibaryBooks()
        {
            //Arange
            Book book1 = new Book(new List<string>() { "Sarah Blædel" }, "Elnis død", "Politikens Forlag", 2022, 336);
            Book book2 = new Book(new List<string>() { "Tine Høeg" }, "Sult", "Gutkind", 2022, 430);
            Book book3 = new Book(new List<string>() { "Matt Haig" }, "The Midnight Libary", "Main", 2021, 304);
            Book book4 = new Book(new List<string>() { "Jón Kalman Stefánsson" }, "Dit fravær er mørke", "Batzer & Co.", 2022, 576);
            Book book5 = new Book(new List<string>() { "Paru Itagaki" }, "Beastars, Vol1", "Viz Media.", 2019, 208);

            Book book6 = new Book(new List<string>() { "Lars Findsen", "Mette Mayli Albæk" }, "Spionchefen - Erindringer fra celle 18", "Politikens Forlag.", 2022, 252);

            Shelf bookShelf1 = new Shelf(46, new List<ShelfSlot>()
            {
                new ShelfSlot(book5, 38),
                new ShelfSlot(book3, 85)
            });
            Shelf bookShelf2 = new Shelf(33, new List<ShelfSlot>()
            {
                new ShelfSlot(book1, 98),
                new ShelfSlot(book2, 222),
                new ShelfSlot(book4, 923)
            });

            Libary testLibary = new Libary(new List<Shelf>() { bookShelf1, bookShelf2 });


            //Act
            Shelf result = testLibary.InsertBooks(new List<ShelfSlot>()
            {
                new ShelfSlot(book6, 5879)
            }, 46); ;

            //Assert
            Assert.AreEqual(result.shelfID, 46, "The search did not return the right shelf");
            Assert.AreEqual(result.ShelfSlot.Count, 3, "Did not find all books in result 1");
            Assert.AreEqual(result.ShelfSlot[2].book.Title, book6.Title, "Book 5 was not found");

        }

        #endregion

    }
}