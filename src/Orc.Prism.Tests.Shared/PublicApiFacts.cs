// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublicApiFacts.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Prism.Tests
{
    using ApiApprover;
    using NUnit.Framework;

    [TestFixture]
    public class PublicApiFacts
    {
#if PRISM5
        [Test]
        public void Orc_Prism5_HasNoBreakingChanges()
        {
            var assembly = typeof(BootstrapperBase).Assembly;

            PublicApiApprover.ApprovePublicApi(assembly);
        }
#endif

#if PRISM6
        [Test]
        public void Orc_Prism6_HasNoBreakingChanges()
        {
            var assembly = typeof(BootstrapperBase).Assembly;

            PublicApiApprover.ApprovePublicApi(assembly);
        }
#endif
    }
}