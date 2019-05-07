using System;
using UnityEngine;
using System.Reactive;
using System.Reactive.Subjects;

namespace USM
{
    public class Example {
      public Example()
      {
        ISubject<string> s = new Subject<string>();

        s.Subscribe(val => Debug.Log(val));

        s.OnNext("Hello world!");
      }
    }
}
