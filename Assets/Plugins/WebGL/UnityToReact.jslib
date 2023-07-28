mergeInto(LibraryManager.library, {
  GameReady: function () {
    window.dispatchReactUnityEvent("GameReady");
  },
  IncrementRun: function (message) {
    window.dispatchReactUnityEvent("IncrementRunFromUnity", UTF8ToString(message));
  },
  InitPlayer: function (playerName) {
    window.dispatchReactUnityEvent("InitPlayerFromUnity", UTF8ToString(playerName));
  },
});