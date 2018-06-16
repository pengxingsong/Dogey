﻿using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Dogey
{
    public class RequireEnabledAttribute : PreconditionAttribute
    {
        public override async Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            var db = (RootController)services.GetService(typeof(RootController));

            bool disabled = await db.ModuleEnabledAsync(context.Guild, command.Module.Name);
            if (disabled)
                return PreconditionResult.FromError(string.Empty);
            return PreconditionResult.FromSuccess();
        }
    }
}