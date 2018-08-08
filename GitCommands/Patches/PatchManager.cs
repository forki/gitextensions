using System.Diagnostics;
        public static byte[] GetResetWorkTreeLinesAsPatch([NotNull] GitModule module, [NotNull] string text, int selectionPosition, int selectionLength, [NotNull] Encoding fileContentEncoding)
            string body = ToResetWorkTreeLinesPatch(selectedChunks);
        public static byte[] GetSelectedLinesAsPatch([NotNull] string text, int selectionPosition, int selectionLength, bool isIndex, [NotNull] Encoding fileContentEncoding, bool isNewFile)
            string body = ToIndexPatch(selectedChunks, isIndex, isWholeFile: false);
            string[] headerLines = header.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    sb.Append(pppLine).Append('\n');
                    sb.Append(line).Append('\n');
            var selectedChunks = FromNewFile(module, text, selectionPosition, selectionLength, reset, filePreamble, fileContentEncoding);
            string body = ToIndexPatch(selectedChunks, isIndex: false, isWholeFile: true);

            if (body == null)
                return null;

            // git apply has problem with dealing with autocrlf
            // I noticed that patch applies when '\r' chars are removed from patch if autocrlf is set to true
            if (reset && module.EffectiveConfigFile.core.autocrlf.ValueOrDefault == AutoCRLFType.@true)
                body = body.Replace("\r", "");
            const string fileMode = "100000"; // given fake mode to satisfy patch format, git will override this
            var header = new StringBuilder();
            header.Append("diff --git a/").Append(newFileName).Append(" b/").Append(newFileName).Append('\n');
            if (!reset)
                header.Append("new file mode ").Append(fileMode).Append('\n');
            header.Append("index 0000000..0000000\n");

            if (reset)
                header.Append("--- a/").Append(newFileName).Append('\n');
                header.Append("--- /dev/null").Append('\n');

            header.Append("+++ b/").Append(newFileName).Append('\n');

            return GetPatchBytes(header.ToString(), body, fileContentEncoding);
            return new[] { Chunk.FromNewFile(module, text, selectionPosition, selectionLength, reset, filePreamble, fileContentEncoding) };
        private static string ToResetWorkTreeLinesPatch([NotNull, ItemNotNull] IEnumerable<Chunk> chunks)
                return subChunk.ToResetWorkTreeLinesPatch(ref addedCount, ref removedCount, ref wereSelectedLines);
        private static string ToIndexPatch([NotNull, ItemNotNull] IEnumerable<Chunk> chunks, bool isIndex, bool isWholeFile)
                return subChunk.ToIndexPatch(ref addedCount, ref removedCount, ref wereSelectedLines, isIndex, isWholeFile);
    [DebuggerDisplay("{" + nameof(Text) + "}")]
        public string ToIndexPatch(ref int addedCount, ref int removedCount, ref bool wereSelectedLines, bool isIndex, bool isWholeFile)
            bool selectedLastRemovedLine = false;
            bool selectedLastAddedLine = false;
            foreach (var removedLine in RemovedLines)
                selectedLastAddedLine = removedLine.Selected;
                else if (!isIndex)
            foreach (var addedLine in AddedLines)
                selectedLastRemovedLine = addedLine.Selected;
                else if (isIndex)
            if (PostContext.Count == 0 && (selectedLastRemovedLine || !isIndex))
            if (PostContext.Count == 0 && (selectedLastAddedLine || isIndex || isWholeFile))
        [CanBeNull]
        public string ToResetWorkTreeLinesPatch(ref int addedCount, ref int removedCount, ref bool wereSelectedLines)