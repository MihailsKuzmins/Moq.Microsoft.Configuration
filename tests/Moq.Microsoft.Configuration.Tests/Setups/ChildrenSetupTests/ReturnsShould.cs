﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.ChildrenSetupTests
{
	public sealed class ReturnsShould : MockTestsBase
	{
		[Fact]
		public void Exist()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Exists();

			result
				.Should()
				.BeTrue();
		}

		[Fact]
		public void ReturnStringEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				//.Append(null)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<string>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnStringArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				.Append(null)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<string[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnStringList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				//.Append(null)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<string>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnStringBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				.Append(null)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = fixture.Object[$"{key}:{i}"];

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnBoolEnumerable()
		{
			const string key = nameof(key);
			var input = new[] { true, false, true };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<bool>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnBoolArray()
		{
			const string key = nameof(key);
			var input = new[] { true, false, true };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<bool[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnBoolList()
		{
			const string key = nameof(key);
			var input = new[] { true, false, true };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<bool>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnBoolBrackets()
		{
			const string key = nameof(key);
			var input = new[] { true, false, true };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = bool.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableBoolEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new bool?[] { true, false, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<bool?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<bool?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableBoolArray()
		{
			const string key = nameof(key);
			var input = new bool?[] { true, false, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<bool?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableBoolList()
		//{
		//	const string key = nameof(key);
		//	var input = new bool?[] { true, false, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<bool?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<bool?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableBoolBrackets()
		{
			const string key = nameof(key);
			var input = new bool?[] { true, false, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (bool?)null : throw new Exception(),
					_ => bool.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnCharEnumerable()
		{
			const string key = nameof(key);
			var input = new[] { 'A', 'b', '3' };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<char>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnCharArray()
		{
			const string key = nameof(key);
			var input = new[] { 'A', 'b', '3' };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<char[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnCharList()
		{
			const string key = nameof(key);
			var input = new[] { 'A', 'b', '3' };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<char>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnCharBrackets()
		{
			const string key = nameof(key);
			var input = new[] { 'A', 'b', '3' };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = char.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableCharEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new char?[] { 'A', 'b', null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<char?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<char?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableCharArray()
		{
			const string key = nameof(key);
			var input = new char?[] { 'A', 'b', null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<char?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableCharList()
		//{
		//	const string key = nameof(key);
		//	var input = new char?[] { 'A', 'b', null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<char?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<char?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableCharBrackets()
		{
			const string key = nameof(key);
			var input = new char?[] { 'A', 'b', null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (char?)null : throw new Exception(),
					_ => char.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnByteEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<byte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnByteArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<byte[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnByteList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<byte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnByteBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = byte.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableByteEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new byte?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<byte?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<byte?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableByteArray()
		{
			const string key = nameof(key);
			var input = new byte?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<byte?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableByteList()
		//{
		//	const string key = nameof(key);
		//	var input = new byte?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<byte?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<byte?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableByteBrackets()
		{
			const string key = nameof(key);
			var input = new byte?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (byte?)null : throw new Exception(),
					_ => byte.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnSbyteEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<sbyte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnSbyteArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<sbyte[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnSbyteList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<sbyte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnSbyteBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = sbyte.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableSbyteEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new sbyte?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<sbyte?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<sbyte?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableSbyteArray()
		{
			const string key = nameof(key);
			var input = new sbyte?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<sbyte?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableSbyteList()
		//{
		//	const string key = nameof(key);
		//	var input = new sbyte?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<sbyte?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<sbyte?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableSbyteBrackets()
		{
			const string key = nameof(key);
			var input = new sbyte?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (sbyte?)null : throw new Exception(),
					_ => sbyte.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnIntEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<int>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<int>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnIntArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<int>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<int[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnIntList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<int>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<int>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnIntBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<int>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = int.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableIntEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new int?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<int?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<int?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableIntArray()
		{
			const string key = nameof(key);
			var input = new int?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<int?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<int?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableIntList()
		//{
		//	const string key = nameof(key);
		//	var input = new int?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<int?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<int?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableIntBrackets()
		{
			const string key = nameof(key);
			var input = new int?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<int?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (int?)null : throw new Exception(),
					_ => int.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnUintEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt32)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<uint>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUintArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt32)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<uint[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUintList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt32)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<uint>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUintBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt32)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = uint.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableUintEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new uint?[] { 1u, 2u, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<uint?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<uint?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableUintArray()
		{
			const string key = nameof(key);
			var input = new uint?[] { 1u, 2u, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<uint?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableUintList()
		//{
		//	const string key = nameof(key);
		//	var input = new uint?[] { 1u, 2u, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<uint?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<uint?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableUintBrackets()
		{
			const string key = nameof(key);
			var input = new uint?[] { 1u, 2u, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (uint?)null : throw new Exception(),
					_ => uint.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnLongEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<long>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<long>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnLongArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<long>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<long[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnLongList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<long>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<long>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnLongBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<long>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = long.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableLongEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new long?[] { 1L, 2L, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<long?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<long?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableLongArray()
		{
			const string key = nameof(key);
			var input = new long?[] { 1L, 2L, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<long?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<long?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableLongList()
		//{
		//	const string key = nameof(key);
		//	var input = new long?[] { 1L, 2L, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<long?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<long?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableLongBrackets()
		{
			const string key = nameof(key);
			var input = new long?[] { 1L, 2L, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<long?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (long?)null : throw new Exception(),
					_ => long.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnUlongEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<ulong>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUlongArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<ulong[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUlongList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<ulong>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUlongBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = ulong.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableUlongEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new ulong?[] { 1UL, 2UL, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<ulong?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<ulong?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableUlongArray()
		{
			const string key = nameof(key);
			var input = new ulong?[] { 1UL, 2UL, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<ulong?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableUlongList()
		//{
		//	const string key = nameof(key);
		//	var input = new ulong?[] { 1UL, 2UL, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<ulong?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<ulong?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableUlongBrackets()
		{
			const string key = nameof(key);
			var input = new ulong?[] { 1UL, 2UL, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (ulong?)null : throw new Exception(),
					_ => ulong.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnShortEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<short>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<short>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnShortArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<short>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<short[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnShortList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<short>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<short>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnShortBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<short>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = short.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableShortEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new short?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<short?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<short?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableShortArray()
		{
			const string key = nameof(key);
			var input = new short?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<short?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<short?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableShortList()
		//{
		//	const string key = nameof(key);
		//	var input = new short?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<short?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<short?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableShortBrackets()
		{
			const string key = nameof(key);
			var input = new short?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<short?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (short?)null : throw new Exception(),
					_ => short.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnUshortEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<ushort>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUshortArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<ushort[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUshortList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<ushort>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUshortBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = ushort.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableUshortEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new ushort?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<ushort?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<ushort>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableUshortArray()
		{
			const string key = nameof(key);
			var input = new ushort?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<ushort?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableUshortList()
		//{
		//	const string key = nameof(key);
		//	var input = new ushort?[] { 1, 2, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<ushort?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<ushort?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableUshortBrackets()
		{
			const string key = nameof(key);
			var input = new ushort?[] { 1, 2, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (ushort?)null : throw new Exception(),
					_ => ushort.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnDecimalEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDecimal)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<decimal>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDecimalArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDecimal)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<decimal[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDecimalList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDecimal)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<decimal>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDecimalBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDecimal)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = decimal.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableDecimalEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new decimal?[] { 1m, 2m, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<decimal?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<decimal?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableDecimalArray()
		{
			const string key = nameof(key);
			var input = new decimal?[] { 1m, 2m, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<decimal?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableDecimalList()
		//{
		//	const string key = nameof(key);
		//	var input = new decimal?[] { 1m, 2m, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<decimal?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<decimal?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableDecimalBrackets()
		{
			const string key = nameof(key);
			var input = new decimal?[] { 1m, 2m, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (decimal?)null : throw new Exception(),
					_ => decimal.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnDoubleEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDouble)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<double>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<double>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDoubleArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDouble)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<double>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<double[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDoubleList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDouble)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<double>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<double>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDoubleBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDouble)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<double>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = double.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableDoubleEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new double?[] { 1d, 2d, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<double?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<double?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableDoubleArray()
		{
			const string key = nameof(key);
			var input = new double?[] { 1d, 2d, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<double?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<double?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableDoubleList()
		//{
		//	const string key = nameof(key);
		//	var input = new double?[] { 1d, 2d, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<double?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<double?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableDoubleBrackets()
		{
			const string key = nameof(key);
			var input = new double?[] { 1d, 2d, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<double?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (double?)null : throw new Exception(),
					_ => double.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}

		[Fact]
		public void ReturnFloatEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSingle)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<float>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<float>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnFloatArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSingle)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<float>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<float[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnFloatList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSingle)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<float>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<float>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnFloatBrackets()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSingle)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<float>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var result = float.Parse(
					fixture.Object[$"{key}:{i}"]);

				result
					.Should()
					.Be(input[i]);
			}
		}

		//[Fact]
		//public void ReturnNullableFloatEnumerable()
		//{
		//	const string key = nameof(key);
		//	var input = new float?[] { 1f, 2f, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<float?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<IEnumerable<float?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableFloatArray()
		{
			const string key = nameof(key);
			var input = new float?[] { 1f, 2f, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<float?>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<float?[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		//[Fact]
		//public void ReturnNullableFloatList()
		//{
		//	const string key = nameof(key);
		//	var input = new float?[] { 1f, 2f, null };

		//	var fixture = CreateClass();

		//	fixture
		//		.SetupChildren<float?>(key)
		//		.Returns(input);

		//	var result = fixture.Object
		//		.GetSection(key)
		//		.Get<List<float?>>();

		//	result
		//		.Should()
		//		.BeEquivalentTo(input);
		//}

		[Fact]
		public void ReturnNullableFloatBrackets()
		{
			const string key = nameof(key);
			var input = new float?[] { 1f, 2f, null };

			var fixture = CreateClass();

			fixture
				.SetupChildren<float?>(key)
				.Returns(input);

			for (var i = 0; i < input.Length; i++)
			{
				var stringValue = fixture.Object[$"{key}:{i}"];

				var result = input[i] switch
				{
					null => stringValue == null ? (float?)null : throw new Exception(),
					_ => float.Parse(stringValue)
				};

				result
					.Should()
					.Be(input[i]);
			}
		}
	}
}
