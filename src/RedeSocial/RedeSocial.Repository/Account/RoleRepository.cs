﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Account;
using RedeSocial.Domain.Account.Repository;
using RedeSocial.Repository.Context;


namespace RedeSocial.Repository.Account
{
        public class RoleRepository : IRoleStore<Role>, IRoleRepository
    {
        private bool disposedValue;

        private RedeSocialContext Context { get; set; }

        public RoleRepository(RedeSocialContext redeSocialContext)
        {
            this.Context = redeSocialContext;
        }

        #region Tasks
        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            this.Context.Roles.Add(role);
            await this.Context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            this.Context.Roles.Remove(role);
            await this.Context.SaveChangesAsync();
            return IdentityResult.Success;

        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await this.Context.Roles.FirstOrDefaultAsync(x => x.Id == new Guid(roleId));
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await this.Context.Roles.FirstOrDefaultAsync(x => x.Name == normalizedRoleName);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.Name = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            var roleToUpdate = await this.Context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == role.Id);

            roleToUpdate = role;
            this.Context.Entry(roleToUpdate).State = EntityState.Modified;

            this.Context.Roles.Add(roleToUpdate);
            await this.Context.SaveChangesAsync();

            return IdentityResult.Success;


        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ProfileRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        
        #endregion

        public Role GetRoleById(Guid id)
        {
            return this.Context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public Role GetRolebyName(string name)
        {
            return this.Context.Roles.FirstOrDefault(x => x.Name == name);
        }
    }
}