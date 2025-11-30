**Foundation Programs Design**

This document contains the individual design for the two Foundation programs for Week 04: the YouTube Videos program (Abstraction) and the Online Ordering program (Encapsulation). Each program design lists the classes, responsibilities, attributes, methods, a simple class diagram, and a brief runtime flow.

**YouTube Videos Design**

- **What the program does:**
  - Stores information for a set of YouTube videos and the comments on each video. Creates several videos with comments, then displays each video's title, author, length, number of comments, and the comment list.

- **Candidate classes:**
  - `Video` — represents a YouTube video and owns a list of `Comment` objects.
  - `Comment` — represents a single comment (author + text).
  - `Program` — constructs sample objects and prints output. (Tester/runner)

- **Responsibilities (brief):**
  - `Video`: store video metadata (title, author, length), manage comments collection, return comment count, format display of video info.
  - `Comment`: store commenter name and comment text; provide a textual representation.
  - `Program`: create sample `Video` objects, populate each with `Comment`s, and iterate to display information.

- **Attributes (member variables)**
  - `Video`:
    - _title : string
    - _author : string
    - _lengthSeconds : int
    - _comments : List<Comment>
  - `Comment`:
    - _author : string
    - _text : string

- **Methods (public API)**
  - `Video`:
    - `AddComment(Comment c)` — add a comment to the video.
    - `GetNumberOfComments()` — return the comment count (int).
    - `GetComments()` — return IEnumerable<Comment> for iteration.
    - `ToString()` — formatted title/author/length + comment count (used for display).
  - `Comment`:
    - `ToString()` — return "Author: Text" or similar.

- **Simple class diagram (text)**
  - Video
    - - -
    - title: string
    - author: string
    - lengthSeconds: int
    - comments: List<Comment>
    - +AddComment(c)
    - +GetNumberOfComments()
    - +GetComments()

  - Comment
    - - -
    - author: string
    - text: string
    - +ToString()

- **Runtime flow / sequence (high level)**
  1. `Program.Main` constructs 3–4 `Video` instances.
  2. For each `Video` instance, create 3–4 `Comment` objects and call `video.AddComment(...)`.
  3. Store the `Video` instances in a collection (List<Video>).
  4. Iterate videos: for each video, print `video.ToString()`, then iterate `video.GetComments()` printing each `Comment.ToString()`.

- **Notes / extensions (optional)**
  - Add methods to compute average comment length or to filter comments.
  - Replace `Program` hard-coded data by loading sample data from a file (JSON or CSV) for more realism.

**Online Ordering Design**

- **What the program does:**
  - Simulates an ordering system: stores products and customers (with addresses), computes order totals including shipping, and produces packing and shipping labels.

- **Candidate classes:**
  - `Product` — represents a product line (name, id, price, quantity) and computes product total.
  - `Address` — represents a postal address with a method to check whether it's in the USA and a formatted full-address string.
  - `Customer` — stores a name and an `Address`; exposes a convenience method `IsInUSA()`.
  - `Order` — contains a list of `Product` items and a `Customer`; calculates total price (products sum + shipping), generates packing and shipping labels.
  - `Program` — creates sample orders and prints labels and totals.

- **Responsibilities (brief):**
  - `Product`: encapsulate product fields and compute the product subtotal (price * quantity).
  - `Address`: hold address fields and know whether the address belongs to the USA; provide formatted address string.
  - `Customer`: hold name + address and provide helper to determine in-USA status.
  - `Order`: aggregate products and customer; calculate shipping cost (based on `Customer.IsInUSA()`), compute total price, and generate packing and shipping label strings.

- **Attributes (member variables)**
  - `Product`:
    - _name : string
    - _productId : string
    - _price : double
    - _quantity : int
  - `Address`:
    - _street : string
    - _city : string
    - _stateOrProvince : string
    - _country : string
  - `Customer`:
    - _name : string
    - _address : Address
  - `Order`:
    - _customer : Customer
    - _products : List<Product>

- **Methods (public API)**
  - `Product`:
    - `GetTotalCost()` — return price * quantity.
  - `Address`:
    - `IsInUSA()` — boolean (examine `_country`, normalize case/spacing).
    - `GetFullAddress()` — return multiline formatted address string.
  - `Customer`:
    - `IsInUSA()` — delegate to `_address.IsInUSA()`.
  - `Order`:
    - `AddProduct(Product p)` — add an item to the order.
    - `GetTotalPrice()` — sum(product totals) + shipping cost.
    - `GetPackingLabel()` — return a string listing product names and product ids.
    - `GetShippingLabel()` — return a string containing the customer's name and full address.

- **Simple class diagram (text)**
  - Product
    - - -
    - name: string
    - productId: string
    - price: double
    - quantity: int
    - +GetTotalCost()

  - Address
    - - -
    - street: string
    - city: string
    - stateOrProvince: string
    - country: string
    - +IsInUSA()
    - +GetFullAddress()

  - Customer
    - - -
    - name: string
    - address: Address
    - +IsInUSA()

  - Order
    - - -
    - customer: Customer
    - products: List<Product>
    - +AddProduct(p)
    - +GetTotalPrice()
    - +GetPackingLabel()
    - +GetShippingLabel()

- **Runtime flow / sequence (high level)**
  1. `Program.Main` constructs two or more `Customer` instances with `Address` objects.
  2. For each customer, create an `Order` and add 2–3 `Product` instances with quantity > 0.
  3. For each `Order`, call `GetPackingLabel()` and `GetShippingLabel()` and print them.
  4. Also call `GetTotalPrice()` and print the formatted total (currency) for each order.

- **Business rules / details**
  - Shipping cost is a one-time charge per order: $5 for USA addresses, $35 otherwise.
  - All product totals are price * quantity — use a `double` for currency in this simple exercise (or decimal for better precision).
  - `Address.IsInUSA()` should normalize the `_country` string (trim, ToLower) and accept common variants ("usa", "us", "united states", "united states of america").

- **Notes / possible extensions**
  - Use `decimal` instead of `double` for prices to avoid rounding issues in real-world code.
  - Persist orders to a text file or load product lists from CSV/JSON.
  - Add unit tests for `Order.GetTotalPrice()` and `Address.IsInUSA()`.

**Design relations / mapping to code in repository**

- For YouTube Videos, map `Comment.cs` and `Video.cs` to the classes above; `Program.cs` will act as the runner.
- For Online Ordering, map `Product.cs`, `Address.cs`, `Customer.cs`, and `Order.cs` to the classes above; `Program.cs` will create sample orders and print labels and totals.

**Diagram notes**

- The diagrams in this document are textual and intended for quick review. If a UML image is required, a simple tool (PlantUML) or hand-drawn PNG may be added to the repo later.

**How the designs meet the assignment requirements**

- Both programs separate concerns: data-holding objects (Product, Comment, Address, Word, etc.) encapsulate state and provide methods for behavior; runner code (`Program`) composes objects and coordinates actions.
- The Online Ordering design enforces encapsulation by keeping member variables private and exposing behavior through methods.
- The Scripture/YouTube/OnlineOrdering designs use constructors, getters, and methods to satisfy OOP principles required by the assignments.

If you want, I can:
- generate simple UML PNGs from these class diagrams (using PlantUML) and add them to the repo,
- convert this document into a more formal README or a printable PDF,
- or open a short interactive checklist to walk team members through completing the assigned coding tasks.

End of design document.
