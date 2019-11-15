﻿using System;
using System.Collections.Generic;

namespace Prise.Infrastructure.NetCore
{
    public class ProbingPathsProvider : IProbingPathsProvider
    {
        private IList<string> probingPaths;
        protected bool disposed = false;
        public ProbingPathsProvider()
        {
            this.probingPaths = new List<String>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                // Nothing to do here
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ProbingPathsProvider AddProbingPath(string path)
        {
            this.probingPaths.Add(path);
            return this;
        }

        public IEnumerable<string> GetProbingPaths() => this.probingPaths;
    }
}
