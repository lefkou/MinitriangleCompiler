using System;
using System.Collections.Generic;
using System.IO;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public class SourceFile : IEnumerator<int>
    {
        StreamReader _source;

        string _buffer;

        int _index;

        int _lineNumber;

        public SourceFile(string sourceFileName)
        {
            Name = sourceFileName;
            try
            {
                _source = new StreamReader(new FileStream(sourceFileName, FileMode.Open));
                Reset();
            }
            catch (FileNotFoundException)
            {
                _source = null;
            }
        }

        public string Name { get; private set; }

        public bool IsValid { get { return _source != null; } }

        public int Current { get { return _buffer == null ? -1 : _buffer[_index]; } }

        object System.Collections.IEnumerator.Current { get { return Current; } }

        public bool SkipRestOfLine()
        {
            _index = _buffer.Length;
            return MoveNext();
        }

        public bool MoveNext()
        {
            if (_buffer != null)
            {
                _index++;

                if (_index >= _buffer.Length)
                {
                    ReadLine();
                }
            }

            return _buffer != null;
        }

        public void Reset()
        {
            if (_source == null) { throw new InvalidOperationException(); }
            if (!_source.BaseStream.CanSeek) { throw new NotSupportedException(); }

            _source.BaseStream.Seek(0L, SeekOrigin.Begin);
            _source.DiscardBufferedData();

            _index = 0;
            _lineNumber = 0;

            ReadLine();
        }

        void ReadLine()
        {
            _buffer = _source.ReadLine();
            if (_buffer != null) { _buffer += "\n"; }

            _index = 0;
            _lineNumber++;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_source != null)
                {
                    _source.Dispose();
                    _source = null;
                }
            }
        }
    }
}