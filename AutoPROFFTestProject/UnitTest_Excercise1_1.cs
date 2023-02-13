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

            Libary libary = new Libary(new List<Book>()
            {
                book1, book2
            });

            //Act
            Book book = new Book();

            //List<Book> bookResult1 = libary.FindBooks("*20*");

            List<Book> bookResult2 = libary.FindBooks("*20* & *Peter*");

            //Assert
            //Assert.AreEqual((int)bookResult1.Count, 2, "Find books didn't find the correct amount of books. Expected amount is 2");
            Assert.AreEqual((int)bookResult2.Count, 1, "Find books didn't find the correct amount of books. Expected amount is 1");
            //Assert.AreEqual(((Book)bookResult1[0]).Title, title1, "Could not find the title in the returned data of search 1");
            Assert.AreEqual(((Book)bookResult2[0]).Title, title2, "Could not find the title in the returned data of search 2");


        }

        #endregion

    }
}