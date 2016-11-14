﻿using System;
using System.ComponentModel;
using Plugin.MediaManager.Abstractions.EventArguments;

namespace Plugin.MediaManager.Abstractions.Implementations
{
    public class MediaFile : IMediaFile
    {
        public MediaFile() : this(String.Empty, MediaFileType.Other)
        {
        }

        public MediaFile(string url, MediaFileType type)
        {
            Url = url;
            Type = type;
            Metadata = new MediaFileMetadata();
        }

        public Guid Id { get; set; } = new Guid();

        public MediaFileType Type { get; set; }

        public IMediaFileMetadata Metadata { get; set; }

        public string Url { get; set; }

        private bool _metadataExtracted;
        public bool MetadataExtracted { get {
                return _metadataExtracted;
            } set {
                _metadataExtracted = value;
                MetadataUpdated?.Invoke(this, new MetadataChangedEventArgs(Metadata));
            } }

        public event MetadataUpdatedEventHandler MetadataUpdated;
    }
}