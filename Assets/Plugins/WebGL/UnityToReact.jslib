mergeInto(LibraryManager.library, {
  GameReady: function () {
    window.dispatchReactUnityEvent("GameReady");
  },
  IncrementCounter: function (message) {
    window.dispatchReactUnityEvent("IncrementCounterFromUnity", UTF8ToString(message));
  },
  InitPlayer: function (playerName) {
    window.dispatchReactUnityEvent("InitPlayerFromUnity", UTF8ToString(playerName));
  },
});