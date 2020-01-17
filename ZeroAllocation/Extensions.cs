using System;
using System.Threading;
using System.Threading.Tasks;

namespace ZeroAllocation
{
    public static class ZeroAllocation
{
	public static void ThrowOnAllocation<ReturnT>(this Action action)
	{
		var task = new Thread(() =>
		{
			// First call causes a lot of allocation. Do it twice to get
			// that out of the way.
			_ = GC.GetAllocatedBytesForCurrentThread();
	
			var init = GC.GetAllocatedBytesForCurrentThread();
	
			// Invoke our action.
			action?.Invoke();
	
			var final = GC.GetAllocatedBytesForCurrentThread();
			if (final - init > 0) throw new Exception("Allocation Found.");
	
		});
	
		task.Start();
	}
	
	public static ReturnT ThrowOnAllocation<ReturnT>(this Func<ReturnT> func)
	{
		ReturnT result = default;
	
		var task = new Thread(() =>
		{
			// First call causes a lot of allocation. Do it twice to get
			// that out of the way.
			_ = GC.GetAllocatedBytesForCurrentThread();
	
			var init = GC.GetAllocatedBytesForCurrentThread();
	
			// Invoke our action.
			result = func();
	
			var final = GC.GetAllocatedBytesForCurrentThread();
			if (final - init > 0) throw new Exception("Allocation Found.");
	
		});
	
		task.Start();
		return result;
	}
	
	public static Task<ReturnT> ThrowOnAllocationAsync<ReturnT>(this Func<ReturnT> func)
	{
		TaskCompletionSource<ReturnT> taskCompletionSource = new TaskCompletionSource<ReturnT>();
	
		var task = new Thread(() =>
		{
			// First call causes a lot of allocation. Do it twice to get
			// that out of the way.
			_ = GC.GetAllocatedBytesForCurrentThread();
	
			var init = GC.GetAllocatedBytesForCurrentThread();
	
			// Invoke our action.
			ReturnT result = func();
			taskCompletionSource.TrySetResult(result);
	
			var final = GC.GetAllocatedBytesForCurrentThread();
			if (final - init > 0) throw new Exception("Allocation Found.");
	
		});
	
		task.Start();
		return taskCompletionSource.Task;
	}
	
	public static ReturnT ThrowOnAllocation<T1, ReturnT>(this Func<T1, ReturnT> func, T1 param1)
	{
		ReturnT result = default;
	
		var task = new Thread(() =>
		{
			// First call causes a lot of allocation. Do it twice to get
			// that out of the way.
			_ = GC.GetAllocatedBytesForCurrentThread();
	
			var init = GC.GetAllocatedBytesForCurrentThread();
	
			// Invoke our action.
			result = func(param1);
	
			var final = GC.GetAllocatedBytesForCurrentThread();
			if (final - init > 0) throw new Exception("Allocation Found.");
	
		});
	
		task.Start();
		return result;
	}
	
	public static Task<ReturnT> ThrowOnAllocationAsync<T1, ReturnT>(this Func<T1, ReturnT> func, T1 param1)
	{
		TaskCompletionSource<ReturnT> taskCompletionSource = new TaskCompletionSource<ReturnT>();
	
		var task = new Thread(() =>
		{
			// First call causes a lot of allocation. Do it twice to get
			// that out of the way.
			_ = GC.GetAllocatedBytesForCurrentThread();
	
			var init = GC.GetAllocatedBytesForCurrentThread();
	
			// Invoke our action.
			ReturnT result = func(param1);
			taskCompletionSource.TrySetResult(result);
	
			var final = GC.GetAllocatedBytesForCurrentThread();
			if (final - init > 0) throw new Exception("Allocation Found.");
	
		});
	
		task.Start();
		return taskCompletionSource.Task;
	}
	
	public static ReturnT ThrowOnAllocation<T1, T2, ReturnT>(this Func<T1, T2, ReturnT> func, T1 param1, T2 param2)
	{
		ReturnT result = default;
		
		var task = new Thread(() =>
		{
			// First call causes a lot of allocation. Do it twice to get
			// that out of the way.
			_ = GC.GetAllocatedBytesForCurrentThread();
			
			var init = GC.GetAllocatedBytesForCurrentThread();
			
			// Invoke our action.
			result = func(param1, param2);
			
			var final = GC.GetAllocatedBytesForCurrentThread();
			if (final - init > 0) throw new Exception("Allocation Found.");
			
		});
		
		task.Start();
		return result;
	}
	
	public static Task<ReturnT> ThrowOnAllocationAsync<T1, T2, ReturnT>(this Func<T1, T2, ReturnT> func, T1 param1, T2 param2)
	{
		TaskCompletionSource<ReturnT> taskCompletionSource = new TaskCompletionSource<ReturnT>();
		
		var task = new Thread(() =>
		{
			// First call causes a lot of allocation. Do it twice to get
			// that out of the way.
			_ = GC.GetAllocatedBytesForCurrentThread();
			
			var init = GC.GetAllocatedBytesForCurrentThread();
			
			// Invoke our action.
			ReturnT result = func(param1, param2);
			taskCompletionSource.TrySetResult(result);
			
			var final = GC.GetAllocatedBytesForCurrentThread();
			if (final - init > 0) throw new Exception("Allocation Found.");
			
		});
		
		task.Start();
		return taskCompletionSource.Task;
	}
}

}
