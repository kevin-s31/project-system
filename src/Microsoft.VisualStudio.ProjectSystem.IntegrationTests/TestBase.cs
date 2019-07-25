﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.Test.Apex;
using Microsoft.Test.Apex.VisualStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#nullable disable

namespace Microsoft.VisualStudio.ProjectSystem.VS
{
    [TestClass] // AssemblyInitialize won't be found without it
    public abstract class TestBase : VisualStudioHostTest
    {
        protected TestBase()
        {
            // TestCleanup will fire up another instance of Visual Studio to reset 
            // the AutoloadExternalChanges if it thinks the default changed even if
            // that was just caused by settings to be sync'd. Just turn this feature off.
            SuppressReloadPrompt = false;
        }

        protected override bool IncludeReferencedAssembliesInHostComposition => false; // Do not add things we reference to the MEF Container

        protected override VisualStudioHostConfiguration GetHostConfiguration()
        {
            return new ProjectSystemHostConfiguration();
        }

        protected override OperationsConfiguration GetOperationsConfiguration()
        {
            return new ProjectSystemOperationsConfiguration(TestContext);
        }

        public new void TryShutdownVisualStudioInstance()
        {
            base.TryShutdownVisualStudioInstance();
        }
    }
}
