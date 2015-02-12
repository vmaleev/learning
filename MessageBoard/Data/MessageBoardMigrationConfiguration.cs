using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationConfiguration : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);

#if DEBUG
            if(context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Title = "Test title",
                    Created = DateTime.Now,
                    Body = "Test body, jfhskjdbfkjsdbfhdsbfhsdbfhbdfsdbhf",
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "Repl1",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Me too",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "qqq",
                            Created = DateTime.Now
                        },
                    }
                };

                context.Topics.Add(topic);

                var anotherTopic = new Topic()
                {
                    Title = "Test title",
                    Created = DateTime.Now,
                    Body = "Test body, jfhskjdbfkjsdbfhdsbfhsdbfhbdfsdbhf"
                };

                context.Topics.Add(anotherTopic);

                try
                {
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }

            }
#endif
        }
    }
}
