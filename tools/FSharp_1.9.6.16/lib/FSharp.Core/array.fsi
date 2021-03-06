//=========================================================================
// (c) Microsoft Corporation 2005-2009. 
//=========================================================================

namespace Microsoft.FSharp.Collections

    open System
    open Microsoft.FSharp.Core
    open Microsoft.FSharp.Collections
    open System.Collections.Generic

    /// Basic operations on arrays
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    [<RequireQualifiedAccess>]
    module Array = 

        /// Build a new array that contains the elements of the first array followed by the elements of the second array
        val append: array1:array<'T> -> array2:array<'T> -> array<'T>

        /// Return the average of the elements in the array. If the array is empty an ArgumentException is thrown.
        val inline average   : array:^T array -> ^T   
                                 when ^T : (static member ( + ) : ^T * ^T -> ^T) 
                                 and  ^T : (static member DivideByInt : ^T*int -> ^T) 
                                 and  ^T : (static member Zero : ^T)


        /// Return the average of the elements generated by applying the function to each element of the array.
        /// If the array is empty an ArgumentException is thrown.
        val inline averageBy   : projection:('T -> ^U) -> array:array<'T> -> ^U   
                                    when ^U : (static member ( + ) : ^U * ^U -> ^U) 
                                    and  ^U : (static member DivideByInt : ^U*int -> ^U) 
                                    and  ^U : (static member Zero : ^U)
                                    
        /// Read a range of elements from the first array and write them into the second.
        val blit: source:array<'T> -> sourceIndex:int -> target:array<'T> -> targetIndex:int -> count:int -> unit
        
        /// For each element of the array, apply the given function. Concatenate all the results and return the combined array.
        val collect : mapping:('T -> array<'U>) -> array:array<'T> -> array<'U>

        /// Build a new array that contains the elements of each of the given sequence of arrays
        val concat: arrays:seq<array<'T>> -> array<'T>

        /// Build a new array that contains the elements of the given array
        val copy: array:array<'T> -> array<'T>

        /// Create an array whose elements are all initially the given value.
        val create: count:int -> value:'T -> array<'T>
         
        /// Apply the given function to successive elements, returning the first
        /// result where function returns <c>Some(x)</c> for some <c>x</c>. If the function 
        /// never returns <c>Some(x)</c> then <c>None</c> is returned.
        val tryPick: chooser:('T -> 'U option) -> array:array<'T> -> 'U option

        /// Fill a range of elements of the array with the given value.
        val fill: target:array<'T> -> targetIndex:int -> count:int -> value:'T -> unit

        /// Apply the given function to successive elements, returning the first
        /// result where function returns <c>Some(x)</c> for some <c>x</c>. If the function 
        /// never returns <c>Some(x)</c> then <c>KeyNotFoundException</c> is raised.
        val pick: chooser:('T -> 'U option) -> array:array<'T> -> 'U 

        /// Apply the given function to each element of the array. Return
        /// the array comprised of the results "x" for each element where
        /// the function returns Some(x)
        val choose: chooser:('T -> 'U option) -> array:array<'T> -> 'U array

        /// Return an empty array of the given type
        [<GeneralizableValue>]
        val empty<'T> : array<'T>

        /// Test if any element of the array satisfies the given predicate.
        ///
        /// The predicate is applied to the elements of the input array. If any application 
        /// returns true then the overall result is true and no further elements are tested. 
        /// Otherwise, false is returned.
        val exists: predicate:('T -> bool) -> array:array<'T> -> bool

        /// Test if any pair of corresponding elements of the arrays satisfies the given predicate.
        ///
        /// The predicate is applied to matching elements in the two collections up to the lesser of the 
        /// two lengths of the collections. If any application returns true then the overall result is 
        /// true and no further elements are tested. Otherwise, if one collections is longer 
        /// than the other then the <c>ArgumentException</c> exception is raised. 
        /// Otherwise, false is returned.
        val exists2: predicate:('T1 -> 'T2 -> bool) -> array1:'T1 array -> array2:'T2 array -> bool

        /// Return a new collection containing only the elements of the collection
        /// for which the given predicate returns "true"
        val filter: predicate:('T -> bool) -> array:array<'T> -> array<'T>

        /// Return the first element for which the given function returns 'true'.
        /// Raise <c>KeyNotFoundException</c> if no such element exists.
        val find: predicate:('T -> bool) -> array:array<'T> -> 'T

        /// Return the index of the first element in the array
        /// that satisfies the given predicate. Raise <c>KeyNotFoundException</c> if 
        /// none of the elements satisy the predicate.
        val findIndex: predicate:('T -> bool) -> array:array<'T> -> int

        /// Test if all elements of the array satisfy the given predicate.
        ///
        /// The predicate is applied to the elements of the input collection. If any application 
        /// returns false then the overall result is false and no further elements are tested. 
        /// Otherwise, true is returned.
        val forall: predicate:('T -> bool) -> array:array<'T> -> bool


        /// Test if all corresponding elements of the array satisfy the given predicate pairwise.
        ///
        /// The predicate is applied to matching elements in the two collections up to the lesser of the 
        /// two lengths of the collections. If any application returns false then the overall result is 
        /// false and no further elements are tested. Otherwise, if one collection is longer 
        /// than the other then the <c>ArgumentException</c> exception is raised. 
        /// Otherwise, true is returned.
        val forall2: predicate:('T1 -> 'T2 -> bool) -> array1:'T1 array -> array2:'T2 array -> bool

        /// Apply a function to each element of the collection, threading an accumulator argument
        /// through the computation. If the input function is <c>f</c> and the elements are <c>i0...iN</c> then computes 
        /// <c>f (... (f s i0)...) iN</c>
        val fold: folder:('State -> 'T -> 'State) -> state:'State -> array: array<'T> -> 'State

        /// Apply a function to each element of the array, threading an accumulator argument
        /// through the computation. If the input function is <c>f</c> and the elements are <c>i0...iN</c> then computes 
        /// <c>f i0 (...(f iN s))</c>
        val foldBack: folder:('T -> 'State -> 'State) -> array:array<'T> -> state:'State -> 'State

        /// Apply a function to pairs of elements drawn from the two collections, 
        /// left-to-right, threading an accumulator argument
        /// through the computation.  The two input
        /// arrays must have the same lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        val fold2: folder:('State -> 'T1 -> 'T2 -> 'State) -> state:'State -> array1:'T1 array -> array2:'T2 array -> 'State

        /// Apply a function to pairs of elements drawn from the two collections, right-to-left, 
        /// threading an accumulator argument through the computation.  The two input
        /// arrays must have the same lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        val foldBack2: folder:('T1 -> 'T2 -> 'State -> 'State) -> array1:'T1 array -> array2:'T2 array -> state:'State -> 'State

        /// Get an element from an array
        val get: array:array<'T> -> index:int -> 'T

        /// Create an array given the dimension and a generator function to compute the elements.
        val init: count:int -> initializer:(int -> 'T) -> array<'T>

        /// Create an array where the entries are initially the default value Unchecked.defaultof&lt;'T&gt;. 
        val zeroCreate: count:int -> array<'T>
         
        /// Return true if the given array is empty, otherwise false
        val isEmpty: array:array<'T> -> bool

        /// Apply the given function to each element of the array. 
        val iter: action:('T -> unit) -> array:array<'T> -> unit

        /// Apply the given function to pair of elements drawn from matching indices in two arrays. The
        /// two arrays must have the same lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        val iter2: action:('T1 -> 'T2 -> unit) -> array1:'T1 array -> array2:'T2 array -> unit

        /// Apply the given function to each element of the array.  The integer passed to the
        /// function indicates the index of element.
        val iteri: action:(int -> 'T -> unit) -> array:array<'T> -> unit

        /// Apply the given function to pair of elements drawn from matching indices in two arrays,
        /// also passing the index of the elements. The two arrays must have the same lengths, 
        /// otherwise an <c>ArgumentException</c> is raised.
        val iteri2: action:(int -> 'T1 -> 'T2 -> unit) -> array1:'T1 array -> array2:'T2 array -> unit

        /// Return the length of an array.  You can also use property arr.Length.
        val length: array:array<'T> -> int

        /// Build a new array whose elements are the results of applying the given function
        /// to each of the elements of the array.
        val map: mapping:('T -> 'U) -> array:array<'T> -> 'U array

        /// Build a new collection whose elements are the results of applying the given function
        /// to the corresponding elements of the two collections pairwise.  The two input
        /// arrays must have the same lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        val map2: mapping:('T1 -> 'T2 -> 'U) -> array1:'T1 array -> array2:'T2 array -> 'U array

        /// Build a new collection whose elements are the results of applying the given function
        /// to the corresponding elements of the two collections pairwise, also passing the index of 
        /// the elements.  The two input arrays must have the same lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        val mapi2: mapping:(int -> 'T1 -> 'T2 -> 'U) -> array1:'T1 array -> array2:'T2 array -> 'U array

        /// Build a new array whose elements are the results of applying the given function
        /// to each of the elements of the array. The integer index passed to the
        /// function indicates the index of element being transformed.
        val mapi: mapping:(int -> 'T -> 'U) -> array:array<'T> -> 'U array

        /// Return the greatest of all elements of the array, compared via Operators.max on the function result
        val max     : array:array<'T> -> 'T 

        /// Return the greatest of all elements of the array, compared via Operators.max on the function result
        val maxBy  : projection:('T -> 'U) -> array:array<'T> -> 'T

        /// Return the lowest of all elements of the array, compared via Operators.min
        val min     : array:array<'T> -> 'T 

        /// Return the lowest of all elements of the array, compared via Operators.min on the function result
        val minBy  : projection:('T -> 'U) -> array:array<'T> -> 'T

        /// Build an array from the given list
        val of_list: elements:'T list -> array<'T>

        /// Build a new array from the given enumerable object
        val of_seq: elements:seq<'T> -> array<'T>

        /// Split the collection into two collections, containing the 
        /// elements for which the given predicate returns "true" and "false"
        /// respectively 
        val partition: predicate:('T -> bool) -> array:array<'T> -> array<'T> * array<'T>

        /// Returns an array with all elements permuted according to the
        /// specified permutation
        val permute : indexMap:(int -> int) -> array:array<'T> -> array<'T>

        /// Apply a function to each element of the array, threading an accumulator argument
        /// through the computation. If the input function is <c>f</c> and the elements are <c>i0...iN</c> 
        /// then computes <c>f (... (f i0 i1)...) iN</c>.
        /// Raises ArgumentException if the array has size zero.
        val reduce: reduction:('T -> 'T -> 'T) -> array:array<'T> -> 'T

        /// Apply a function to each element of the array, threading an accumulator argument
        /// through the computation. If the input function is <c>f</c> and the elements are <c>i0...iN</c> 
        /// then computes <c>f i0 (...(f iN-1 iN))</c>.
        /// Raises ArgumentException if the array has size zero.
        val reduceBack: reduction:('T -> 'T -> 'T) -> array:array<'T> -> 'T

        /// Return a new array with the elements in reverse order
        val rev: array:array<'T> -> array<'T>

        /// Like <c>fold_left</c>, but return the intermediary and final results
        val scan : folder:('State -> 'T -> 'State) -> state:'State -> array:array<'T> -> 'State array

        /// Like <c>fold_right</c>, but return both the intermediary and final results
        val scanBack : folder:('T -> 'State -> 'State) -> array:array<'T> -> state:'State -> 'State array

        /// Set an element of an array
        val set: array:array<'T> -> index:int -> value:'T -> unit

        /// Build a new array that contains the given subrange specified by
        /// starting index and length.
        val sub: array:array<'T> -> startIndex:int -> count:int -> array<'T>

        /// Sort the elements of an array, returning a new array. Elements are compared using Operators.compare. 
        val sort: array:array<'T> -> array<'T>

        /// Sort the elements of an array, using the given projection for the keys and returning a new array. Elements are compared using Operators.compare. 
        val sortBy: projection:('T -> 'U) -> array:array<'T> -> array<'T>

        /// Sort the elements of an array, using the given comparison function as the order, returning a new array
        val sortWith: comparer:('T -> 'T -> int) -> array:array<'T> -> array<'T>

        /// Sort the elements of an array by mutating the array in-place, using the given projection for the keys. Elements are compared using Operators.compare.
        val sortInPlaceBy: projection:('T -> 'U) -> array:array<'T> -> unit


        /// Sort the elements of an array by mutating the array in-place, using the given comparison function as the order 
        val sortInPlaceWith: comparer:('T -> 'T -> int) -> array:array<'T> -> unit

        /// Sort the elements of an array by mutating the array in-place, using the given comparison function. Elements are compared using Operators.compare.
        val sortInPlace: array:array<'T> -> unit

        /// Return the sum of the elements in the array
        val inline sum   : array: ^T array -> ^T 
                                when ^T : (static member ( + ) : ^T * ^T -> ^T) 
                                and  ^T : (static member Zero : ^T)


        /// Return the sum of the results generated by applying the function to each element of the array.
        val inline sumBy   : projection:('T -> ^U) -> array:array<'T> -> ^U 
                                  when ^U : (static member ( + ) : ^U * ^U -> ^U) 
                                  and  ^U : (static member Zero : ^U)

        /// Build a list from the given array
        val to_list: array:array<'T> -> 'T list

        /// View the given array as a sequence
        val to_seq: array:array<'T> -> seq<'T>

        /// Return the first element for which the given function returns <c>true</c>.
        /// Return <c>None</c> if no such element exists.
        val tryFind: predicate:('T -> bool) -> array:array<'T> -> 'T option

        /// Return the index of the first element in the array
        /// that satisfies the given predicate.
        val tryFindIndex : predicate:('T -> bool) -> array:array<'T> -> int option

        /// Split an array of pairs into two arrays
        val unzip: array:('T1 * 'T2) array -> ('T1 array * 'T2 array)

        /// Split an array of triples into three arrays
        val unzip3: array:('T1 * 'T2 * 'T3) array -> ('T1 array * 'T2 array * 'T3 array)

        /// Combine the two arrays into an array of pairs. The two arrays must have equal lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        val zip: array1:'T1 array -> array2:'T2 array -> ('T1 * 'T2) array

        /// Combine three arrays into an array of pairs. The three arrays must have equal lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        val zip3: array1:'T1 array -> array2:'T2 array -> array3:'T3 array -> ('T1 * 'T2 * 'T3) array

#if FX_ATLEAST_40
        /// Provides parallel operations on arrays 
        module Parallel =

            /// Apply the given function to each element of the array. Return
            /// the array comprised of the results "x" for each element where
            /// the function returns Some(x).
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to elements of the input array is not specified.
            val choose: chooser:('T -> 'U option) -> array:'T array -> 'U array

            /// For each element of the array, apply the given function. Concatenate all the results and return the combined array.
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to elements of the input array is not specified.
            val collect : mapping:('T -> array<'U>) -> array:array<'T> -> array<'U>
            
            /// Build a new array whose elements are the results of applying the given function
            /// to each of the elements of the array.
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to elements of the input array is not specified.
            val map : mapping:('T -> 'U) -> array:array<'T> -> array<'U>
            
            /// Build a new array whose elements are the results of applying the given function
            /// to each of the elements of the array. The integer index passed to the
            /// function indicates the index of element being transformed.
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to elements of the input array is not specified.
            val mapi: mapping:(int -> 'T -> 'U) -> array:'T array -> 'U array

            /// Apply the given function to each element of the array. 
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to elements of the input array is not specified.
            val iter : action:('T -> unit) -> array:array<'T> -> unit

            /// Apply the given function to each element of the array.  The integer passed to the
            /// function indicates the index of element.
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to elements of the input array is not specified.
            val iteri: action:(int -> 'T -> unit) -> array:'T array -> unit
            
            /// Create an array given the dimension and a generator function to compute the elements.
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to indicies is not specified.
            val init : count:int -> initializer:(int -> 'T) -> array<'T>
            
            /// Split the collection into two collections, containing the 
            /// elements for which the given predicate returns "true" and "false"
            /// respectively 
            ///
            /// Performs the operation in parallel using System.Threading.Parallel.For.
            /// The order in which the given function is applied to indicies is not specified.
            val partition : predicate:('T -> bool) -> array:array<'T> -> array<'T> * array<'T>
#endif            

#if DONT_INCLUDE_DEPRECATED
#else
        [<OCamlCompatibility("This F# library function has been renamed. Use 'zip' instead")>]
        val combine: array1:'T1 array -> array2:'T2 array -> ('T1 * 'T2) array

        [<OCamlCompatibility("This F# library function has been renamed. Use 'unzip' instead")>]
        val split: array:('T1 * 'T2) array -> ('T1 array * 'T2 array)

        [<Obsolete("This F# library function has been renamed. Use 'averageBy' instead")>]
        val inline average_by   : projection:('T -> ^U) -> array:array<'T> -> ^U   
                                    when ^U : (static member ( + ) : ^U * ^U -> ^U) 
                                    and  ^U : (static member DivideByInt : ^U*int -> ^U) 
                                    and  ^U : (static member Zero : ^U)

        [<Obsolete("This F# library function has been renamed. Use 'findIndex' instead")>]
        val find_index: predicate:('T -> bool) -> array:array<'T> -> int

        [<OCamlCompatibility("This F# library function has been renamed. Use 'forall' instead")>]
        val for_all: predicate:('T -> bool) -> array:array<'T> -> bool

        [<OCamlCompatibility("This F# library function has been renamed. Use 'create' instead")>]
        val make: count:int -> value:'T -> array<'T>
         
        [<Obsolete("This F# library function has been renamed. Use 'tryPick' instead")>]
        val first: chooser:('T -> 'U option) -> array:array<'T> -> 'U option

        [<Obsolete("This F# library function has been renamed. Use 'forall2' instead")>]
        val for_all2: predicate:('T1 -> 'T2 -> bool) -> array1:'T1 array -> array2:'T2 array -> bool

        [<OCamlCompatibility("This F# library function has been renamed. Use 'fold' instead")>]
        val fold_left: folder:('State -> 'T -> 'State) -> state:'State -> array: array<'T> -> 'State

        /// Apply a function to each element of the array, threading an accumulator argument
        /// through the computation. If the input function is <c>f</c> and the elements are <c>i0...iN</c> 
        /// then computes <c>f i0 (...(f iN s))</c>
        [<OCamlCompatibility("This F# library function has been renamed. Use 'foldBack' instead")>]
        val fold_right: folder:('T -> 'State -> 'State) -> array:array<'T> -> state:'State -> 'State

        /// Apply a function to pairs of elements drawn from the two collections, 
        /// left-to-right, threading an accumulator argument
        /// through the computation.  The two input
        /// arrays must have the same lengths, otherwise an <c>ArgumentException</c> is
        /// raised.
        [<Obsolete("This F# library function has been renamed. Use 'fold2' instead")>]
        val fold_left2: folder:('State -> 'T1 -> 'T2 -> 'State) -> state:'State -> array1:'T1 array -> array2:'T2 array -> 'State

        [<Obsolete("This F# library function has been renamed. Use 'foldBack2' instead")>]
        val fold_right2: folder:('T1 -> 'T2 -> 'State -> 'State) -> array1:'T1 array -> array2:'T2 array -> state:'State -> 'State

        /// Create an array where the entries are initially the default value Unchecked.defaultof&lt;'T&gt;. 
        [<Obsolete("This F# library function has been renamed. Use 'zeroCreate' instead")>]
        val zero_create: count:int -> array<'T>
         
        [<Obsolete("This F# library function has been renamed. Use 'isEmpty' instead")>]
        val is_empty: array:array<'T> -> bool

        [<Obsolete("This F# library function has been renamed. Use 'maxBy' instead")>]
        val max_by  : projection:('T -> 'U) -> array:array<'T> -> 'T

        [<Obsolete("This F# library function has been renamed. Use 'minBy' instead")>]
        val min_by  : projection:('T -> 'U) -> array:array<'T> -> 'T

        [<Obsolete("This F# library function has been renamed. Use 'reduce' instead")>]
        val reduce_left: reduction:('T -> 'T -> 'T) -> array:array<'T> -> 'T

        [<Obsolete("This F# library function has been renamed. Use 'reduceBack' instead")>]
        val reduce_right: reduction:('T -> 'T -> 'T) -> array:array<'T> -> 'T

        [<Obsolete("This F# library function has been renamed. Use 'scan' instead")>]
        val scan_left : folder:('State -> 'T -> 'State) -> state:'State -> array:array<'T> -> 'State array

        [<Obsolete("This F# library function has been renamed. Use 'scanBack' instead")>]
        val scan_right : folder:('T -> 'State -> 'State) -> array:array<'T> -> state:'State -> 'State array

        /// Sort the elements of an array, using the given projection for the keys. Elements are compared using Operators.compare.
        [<Obsolete("This F# library function has been renamed. Use 'sortInPlaceBy' instead")>]
        val sort_by: projection:('T -> 'U) -> array:array<'T> -> unit

        [<Obsolete("This F# library function has been renamed. Use 'sumBy' instead")>]
        val inline sum_by   : projection:('T -> ^U) -> array:array<'T> -> ^U 
                                  when ^U : (static member ( + ) : ^U * ^U -> ^U) 
                                  and  ^U : (static member Zero : ^U)


        [<Obsolete("This F# library function has been renamed. Use 'tryFind' instead")>]
        val tryfind: predicate:('T -> bool) -> array:array<'T> -> 'T option

        [<Obsolete("This F# library function has been renamed. Use 'tryFindIndex' instead")>]
        val tryfind_index: predicate:('T -> bool) -> array:array<'T> -> int option

        [<Obsolete("This function will be removed from the F# library. Replacement functions 'tryPick' and 'tryFindIndex' are now provided")>]
        val tryfind_indexi: predicate:(int -> 'T -> bool) -> array:array<'T> -> int option

        [<Obsolete("This function will be removed from the F# library. Replacement functions 'pick' and 'findIndex' are now provided")>]
        val find_indexi: predicate:(int -> 'T -> bool) -> array:array<'T> -> int 

#endif
