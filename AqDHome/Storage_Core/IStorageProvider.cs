/*
 * IStorageProvider.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


namespace AqDHome.Storage {

  /// <summary>
  /// IStorageProvider represents a basic storage provider to store anonymous
  /// atoms. It is the bottom layer of this storage system, used to manage real
  /// contents of "files".
  /// </summary>
  public interface IStorageProvider {


    /// <summary>
    /// Create a new atom
    /// </summary>
    /// <returns> The ID of this newly-created atom. </returns>
    /// <exception name="StorageInternalException"> When an unresolvable
    /// internal error occurs.</exception>
    /// <remarks>
    /// The length of the returned ID is no more than 64 chars.
    /// </remarks>
    string CreateAtom();


    /// <summary>
    /// Delete an atom
    /// </summary>
    /// <exception name="StorageInternalException"> When an unresolvable
    /// internal error occurs.</exception>
    /// <exception name="StorageAtomNotFoundException"> When the atom of the given
    /// <paramref name="id"/> doesn't exist. </exception>
    void DeleteAtom(string id);


    /// <summary>
    /// Read an atom's contents
    /// </summary>
    /// <exception name="StorageInternalException"> When an unresolvable
    /// internal error occurs.</exception>
    /// <exception name="StorageAtomNotFoundException"> When the atom of the given
    /// <paramref name="id"/> doesn't exist. </exception>
    /// <remarks>
    /// The contents returned aren't necessarily to be the same as the contents
    /// written by <see cref="IStorageProvider.WriteAtom"/>.
    /// </remarks>
    byte[] ReadAtom(string id);


    /// <summary>
    /// Write into an atom. All old contents are overrided.
    /// </summary>
    /// <exception name="StorageInternalException"> When an unresolvable
    /// internal error occurs.</exception>
    /// <exception name="StorageAtomNotFoundException"> When the atom of the given
    /// <paramref name="id"/> doesn't exist. </exception>
    void WriteAtom(string id, byte[] contents);


  }

}
