﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Navigation;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.VisualStudio.LanguageServices.LiveShare.UnitTests
{
    using Workspace = CodeAnalysis.Workspace;

    [ExportWorkspaceServiceFactory(typeof(IDocumentNavigationService), ServiceLayer.Test), Shared, PartNotDiscoverable]
    internal class MockDocumentNavigationServiceFactory : IWorkspaceServiceFactory
    {
        [ImportingConstructor]
        [Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
        public MockDocumentNavigationServiceFactory()
        {
        }

        public IWorkspaceService CreateService(HostWorkspaceServices workspaceServices)
        {
            return new MockDocumentNavigationService();
        }

        private class MockDocumentNavigationService : IDocumentNavigationService
        {
            public Task<bool> CanNavigateToLineAndOffsetAsync(Workspace workspace, DocumentId documentId, int lineNumber, int offset, CancellationToken cancellationToken) => SpecializedTasks.True;

            public Task<bool> CanNavigateToPositionAsync(Workspace workspace, DocumentId documentId, int position, int virtualSpace, CancellationToken cancellationToken) => SpecializedTasks.True;

            public Task<bool> CanNavigateToSpanAsync(Workspace workspace, DocumentId documentId, TextSpan textSpan, CancellationToken cancellationToken) => SpecializedTasks.True;

            public Task<bool> TryNavigateToLineAndOffsetAsync(Workspace workspace, DocumentId documentId, int lineNumber, int offset, NavigationOptions options, CancellationToken cancellationToken) => SpecializedTasks.True;

            public Task<bool> TryNavigateToPositionAsync(Workspace workspace, DocumentId documentId, int position, int virtualSpace, NavigationOptions options, CancellationToken cancellationToken) => SpecializedTasks.True;

            public Task<bool> TryNavigateToSpanAsync(Workspace workspace, DocumentId documentId, TextSpan textSpan, NavigationOptions options, bool allowInvalidSpan, CancellationToken cancellationToken) => SpecializedTasks.True;
        }
    }
}
