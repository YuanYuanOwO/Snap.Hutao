﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Win32;
using Snap.Hutao.Core.Threading;
using System.IO;

namespace Snap.Hutao.Service.Game.Locator;

/// <summary>
/// 注册表启动器位置定位器
/// </summary>
internal class RegistryLauncherLocator : IGameLocator
{
    /// <inheritdoc/>
    public Task<ValueResult<bool, string>> LocateGamePathAsync()
    {
        return Task.FromResult(LocateInternal("InstallPath", "YuanShen.exe"));
    }

    /// <inheritdoc/>
    public Task<ValueResult<bool, string>> LocateLauncherPathAsync()
    {
        return Task.FromResult(LocateInternal("DisplayIcon"));
    }

    private static ValueResult<bool, string> LocateInternal(string key, string? combine = null)
    {
        RegistryKey? uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\原神");
        if (uninstallKey != null)
        {
            if (uninstallKey.GetValue(key) is string path)
            {
                if (!string.IsNullOrEmpty(combine))
                {
                    path = Path.Combine(combine);
                }

                return new(true, path);
            }
            else
            {
                return new(false, null!);
            }
        }
        else
        {
            return new(false, null!);
        }
    }
}