using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTask
{
        public class UnitOfWork : IDisposable
        {
            private Chat_DbEntities db = new Chat_DbEntities();
            private UsersRepository usersRepository;
            private PrivateMessageRepository privateMessage;
            private GroupMessageRepository groupMessage;

            public UsersRepository Users
            {
                get
                {
                    if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                    return usersRepository;
                }
            }

            public PrivateMessageRepository PrivateMessage
            {
                get
                {
                    if (privateMessage == null)
                    privateMessage = new PrivateMessageRepository(db);
                    return privateMessage;
                }
            }
        public GroupMessageRepository GroupMessage
        {
            get
            {
                if (groupMessage == null)
                    groupMessage = new GroupMessageRepository(db);
                return groupMessage;
            }
        }

        private bool disposed = false;
            public virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    this.disposed = true;
                }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    
}