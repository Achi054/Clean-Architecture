using System;

namespace Clean.Architecture.Concerns.Result
{
    public abstract record Result<T> : Result
    {
        private T _data;

#pragma warning disable CS8618 // _data should not be nullable.
        protected Result(T? data)
#pragma warning restore CS8618 // _data should not be nullable.
        {
            ArgumentNullException.ThrowIfNull(data);

            this.Data = data;
        }

        public T Data
        {
            get => Success ? _data : throw new System.Exception($"You can't access {nameof(Data)} when {nameof(Success)} is false");
            set => _data = value;
        }
    }
}
