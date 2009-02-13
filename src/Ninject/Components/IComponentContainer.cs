﻿#region License
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007-2009, Enkari, Ltd.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
#endregion

namespace Ninject.Components
{
	/// <summary>
	/// An internal container that manages and resolves components that contribute to Ninject.
	/// </summary>
	public interface IComponentContainer : IDisposable
	{
		/// <summary>
		/// Gets or sets the kernel that owns the component container.
		/// </summary>
		IKernel Kernel { get; set; }

		/// <summary>
		/// Registers a service in the container.
		/// </summary>
		/// <typeparam name="TService">The component's service type.</typeparam>
		/// <typeparam name="TImplementation">The component's implementation type.</typeparam>
		void Add<TService, TImplementation>()
			where TService : INinjectComponent
			where TImplementation : TService, INinjectComponent;

		/// <summary>
		/// Removes all registrations for the specified service.
		/// </summary>
		/// <typeparam name="T">The component's service type.</typeparam>
		void RemoveAll<T>() where T : INinjectComponent;

		/// <summary>
		/// Removes all registrations for the specified service.
		/// </summary>
		/// <param name="service">The component's service type.</param>
		void RemoveAll(Type service);

		/// <summary>
		/// Gets one instance of the specified component.
		/// </summary>
		/// <typeparam name="T">The component's service type.</typeparam>
		/// <returns>The instance of the component.</returns>
		T Get<T>() where T : INinjectComponent;

		/// <summary>
		/// Gets all available instances of the specified component.
		/// </summary>
		/// <typeparam name="T">The component's service type.</typeparam>
		/// <returns>A series of instances of the specified component.</returns>
		IEnumerable<T> GetAll<T>() where T : INinjectComponent;

		/// <summary>
		/// Gets one instance of the specified component.
		/// </summary>
		/// <param name="service">The component's service type.</param>
		/// <returns>The instance of the component.</returns>
		object Get(Type service);

		/// <summary>
		/// Gets all available instances of the specified component.
		/// </summary>
		/// <param name="service">The component's service type.</param>
		/// <returns>A series of instances of the specified component.</returns>
		IEnumerable<object> GetAll(Type service);
	}
}