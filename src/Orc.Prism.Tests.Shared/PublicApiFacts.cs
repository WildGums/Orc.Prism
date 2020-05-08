// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublicApiFacts.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Prism.Tests
{
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using ApprovalTests;
    using ApprovalTests.Namers;
    using NUnit.Framework;
    using PublicApiGenerator;

    [TestFixture]
    public class PublicApiFacts
    {
        //#if PRISM5
        //        [Test, MethodImpl(MethodImplOptions.NoInlining)]
        //        public void Orc_Prism5_HasNoBreakingChanges()
        //        {
        //            var assembly = typeof(BootstrapperBase).Assembly;

        //            PublicApiApprover.ApprovePublicApi(assembly);
        //        }
        //#endif

#if PRISM6
        [Test, MethodImpl(MethodImplOptions.NoInlining)]
        public void Orc_Prism6_HasNoBreakingChanges()
        {
            var assembly = typeof(BootstrapperBase).Assembly;

            PublicApiApprover.ApprovePublicApi(assembly);
        }
#endif


        internal static class PublicApiApprover
        {
            public static void ApprovePublicApi(Assembly assembly)
            {
                var publicApi = ApiGenerator.GeneratePublicApi(assembly, new ApiGeneratorOptions());
                var writer = new ApprovalTextWriter(publicApi, "cs");
                var approvalNamer = new AssemblyPathNamer(assembly.Location);
                Approvals.Verify(writer, approvalNamer, Approvals.GetReporter());
            }
        }

        internal class AssemblyPathNamer : UnitTestFrameworkNamer
        {
            private readonly string _name;

            public AssemblyPathNamer(string assemblyPath)
            {
                _name = Path.GetFileNameWithoutExtension(assemblyPath);

            }
            public override string Name
            {
                get { return _name; }
            }
        }
    }
}
