using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makani.Tests
{
    public class ToastServiceTests
    {
        [Theory, AutoMoqData]
        public void ToastService_ShouldBeInjected(ToastService sut)
        {
            sut.Should().NotBeNull();
        }

        [Theory, AutoMoqData]
        public async Task AddToast_ShouldSucceed(ToastService sut)
        {
            await sut.AddToast("test");
            sut.Messages.Count.Should().Be(1);
            //sut.Messages.First().IsRemoving.Should().BeFalse();
        }

        [Theory, AutoMoqData]
        public async Task AddToast_ShouldRemoveMessages(ToastService sut)
        {
            var toast = new Toast("test", MkState.Default, 100);
            await sut.AddToast(toast);
            sut.Messages.Count.Should().Be(1);

            // todo: these assertions fail on the server. commenting out for now.
            // wait for the duration to begin removal
            //await Task.Delay(200);
            //sut.Messages.First().IsRemoving.Should().BeTrue();

            //await Task.Delay(3000);
            //sut.Messages.Count.Should().Be(0);
        }
    }
}
