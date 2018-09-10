using NLog;
using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

public class ProfilingInterceptionBehavior : IInterceptionBehavior
{
    public IMethodReturn Invoke(IMethodInvocation input,
        GetNextInterceptionBehaviorDelegate getNext)
    {
        //This behavior will record the start and stop time
        //of a method and will log the method name and elapsed time.
        //Get the current time.
        var startTime = DateTime.Now;

        //Log the start time of the method.
        //This could be ommitted if you just want to see the response times of a method.
        //WriteLog(String.Format(
        //  "Invoking method {0} at {1}",
        //  input.MethodBase, startTime.ToLongTimeString()));

        // Invoke the next behavior in the chain.
        var result = getNext()(input, getNext);

        //Calculate the elapsed time.
        var endTime = DateTime.Now;
        var timeSpan = endTime - startTime;


        //The following will log the method name and elapsed time.
        if (result.Exception != null)
        {

            insertLog(result.Exception);
            //    //Method threw an exception.          

            //    //WriteLog(String.Format(
            //    //  "Method {0} threw exception {1} at {2}.  Elapsed Time: {3} ms",
            //    //  input.MethodBase, result.Exception.Message,
            //    //  endTime.ToLongTimeString(),
            //    //  timeSpan.TotalMilliseconds));
            //}
            //else
            //{
            //    //Method completed normally.
            //    WriteLog(String.Format(
            //      "Method {0} returned {1} at {2}.  Elapsed Time: {3} ms",
            //      input.MethodBase, result.ReturnValue,
            //      endTime.ToLongTimeString(),
            //      timeSpan.TotalMilliseconds));
        }

        return result;
    }

    public IEnumerable<Type> GetRequiredInterfaces()
    {
        return Type.EmptyTypes;
    }

    public bool WillExecute
    {
        get { return true; }
    }

    //private void WriteLog(string message)
    //{
    //    //if (Log != null)
    //    //{
    //    //    Log.DebugFormat("Profiler: {0}", message);
    //    //}
    //}

    private void insertLog(Exception err)
    {
        var logger = LogManager.GetLogger("db");
        logger.Error(err, "Error");
    }

}