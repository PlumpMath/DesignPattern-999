using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
    public class Bridge
    {
      
 
        public void Demonstrate()
        {

            DesignPatern.Demonstrate();
        }
    }






    #region Correct Pattern




    public static class DesignPatern
    {

        public static void Demonstrate()
        {
            List<Manuscript> documents = new List<Manuscript>();

            var standartFormater = new standartFormatter();

            var backwordFormater = new backwardFormatter();


            var faq = new properFAQ(standartFormater){ Questions = new List<string> { "aa", "bbb" }, Title = "test faq" };
        

            documents.Add(faq);


            var book = new properbook(standartFormater) { Text = "this is book", Title = "book 1", Author = "R. J. Simpson" };

            documents.Add(book);


            var backwbook = new properbook(backwordFormater) { Text = "this is book", Title = "book 1", Author = "R. J. Simpson" };
            backwbook.print();

            var paper = new properTermPaper(standartFormater) { Text = "a paper", Class = "s hand", References = "asdasd", Student = "iuhuu" };

            documents.Add(paper);


            foreach (var document in documents)
            {
                document.print();
            }

            Console.ReadKey();
        }
    }

    public interface IManuscript
    {
        void print();
    }



    public class properTermPaper : Manuscript
    {
        public string Class { get; set; }
        public string Student { get; set; }
        public string Text { get; set; }
        public string References { get; set; }

        public properTermPaper(IFormater formatter):base(formatter)
        {

        } 

        public override void print()
        {
            Console.WriteLine($"Term Paper {formatter.Format("Class:",Class)} - {formatter.Format("student:",Student)}" );
        }
    }


    public class properbook : Manuscript
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public properbook(IFormater formatter): base(formatter)
        {
            
        }
      
        public override void print()
        {
            Console.WriteLine($"I'm backwordBook    { formatter.Format("text", Text)} with  {formatter.Format("Author",Author)} and{formatter.Format("Title", Title)}  ");
        }
    }


 


    public class properFAQ : Manuscript
    {
        public string Title { get; set; }
        public List<string> Questions { get; set; }

        public properFAQ(IFormater formatter): base(formatter)
        {

        }
 
        public override void print()
        {
            Console.WriteLine($"FAQ is {formatter.Format("Title:", Title)} and {formatter.Format("question:", Questions.FirstOrDefault())}");
        }
    }


    public abstract class Manuscript
    {
        protected readonly IFormater formatter;

        public Manuscript(IFormater _formatter)
        {
            formatter = _formatter;
        }

        abstract public void print();
    }

    public interface IFormater
    {
        string Format(string key, string value);
    }



    public class standartFormatter : IFormater
    {
        public string Format(string key, string value)
        {
            return string.Format("{0}:{1}",key,value);
        }
    }


    public class backwardFormatter : IFormater
    {
        public string Format(string key, string value)
        {
            return string.Format("{1}:{0}", key, value);
        }
    }



    public class FancyFormatter : IFormater
    {
        public string Format(string key, string value)
        {
            return string.Format("=>{0} <= ;> {1}", key, value);
        }
    }

    #endregion




    #region Anti Paterrn



    public static class AntiPatern
    {

        public static void Demonstrate()
        {

            var faq = new FAQ { Questions = new List<string> {"aa","bbb" }, Title="test faq"};
            faq.print();


            var book = new book { Text = "this is book", Title = "book 1", Author = "R. J. Simpson" };
            book.print();

            var backwbook = new backwordBook { Text = "this is book", Title = "book 1", Author = "R. J. Simpson" };
            backwbook.print();

            var paper = new TermPaper { Text="a paper", Class="s hand", References="asdasd", Student="iuhuu" };

            paper.print();
        }
    }

    public class  TermPaper : IManuscript
    {
        public string Class { get; set; }
        public string Student { get; set; }
        public string Text { get; set; }
        public string References { get; set; }

        public void print()
        {
            Console.WriteLine("Term Paper");
        }
    }


    public class book : IManuscript
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public virtual void print()
        {
            Console.WriteLine($"I'm Book Title:{Title} with Author: {Author} and Text: {Text}");
        }
    }


    /// <summary>
    /// No good way for ierachy if we want to add to other object this feature
    /// </summary>
    public class backwordBook : book
    {
        public override void print()
        {
            Console.WriteLine($"I'm backwordBook   Text: {Text} with Author: {Author} and Title:{Title}  ");
        }
    }


    public class FAQ : IManuscript
    {
        public string Title { get; set; }
        public List<string> Questions { get; set; }


        public void print()
        {
            Console.WriteLine("FAQ");
        }
    }

    #endregion




}
