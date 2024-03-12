using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.ViewModels
{
    public class MovieCommands
    {
        // 再生
        public ReactiveCommand CreateMoveToStartCommand() { 
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteMoveToStart());
            return command;
        } 
        public ReactiveCommand CreateStartPlayingCommand() {
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteStartPlaying());
            return command;
        
        } 
        public ReactiveCommand CreatePausePlayingCommand() {
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecutePausePlaying());
            return command;
        } 
        public ReactiveCommand CreateFastForwardCommand() { 
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteFastForward());
            return command;
        } 
        public ReactiveCommand CreateRewindCommand() {
            var command = new ReactiveCommand();
            command.Subscribe(_ => ExecuteRewind());
            return command;
        } 

        public MovieCommands()
        {

        }

        private void ExecuteMoveToStart()
        {
            // 「最初に移動」の処理
        }

        private void ExecuteStartPlaying()
        {
            // 「再生開始」の処理
        }

        private void ExecutePausePlaying()
        {
            // 「一時停止」の処理
        }

        private void ExecuteFastForward()
        {
            // 「早送り」の処理
        }

        private void ExecuteRewind()
        {
            // 「巻き戻し」の処理
        }
    }
}
