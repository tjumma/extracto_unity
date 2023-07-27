mergeInto(LibraryManager.library, {
  IncrementCounter: function (message) {
    window.dispatchReactUnityEvent("IncrementCounterFromUnity", UTF8ToString(message));
  },
  InitPlayer: function (playerName) {
    window.dispatchReactUnityEvent("InitPlayerFromUnity", UTF8ToString(playerName));
  },
});