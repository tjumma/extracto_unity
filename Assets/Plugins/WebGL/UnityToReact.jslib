mergeInto(LibraryManager.library, {
  IncrementCounter: function (message) {
    window.dispatchReactUnityEvent("IncrementCounterFromUnity", UTF8ToString(message));
  },
});