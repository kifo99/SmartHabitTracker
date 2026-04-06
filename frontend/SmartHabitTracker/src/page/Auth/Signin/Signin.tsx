const Signin = () => {
  return (
    <div className="min-h-screen flex items-center justify-center bg-background-secondary text-text-primary">
      <div className="flex w-[85%] rounded-2xl overflow-hidden shadow-lg bg-surface">
        {/* LEFT SIDE */}
        <div className="w-1/2 p-10 flex flex-col justify-center gap-6">
          <h1 className="text-3xl font-bold">Welcome back</h1>
          <p className="text-sm">Please enter your details to sign in</p>

          <div className="flex flex-col gap-2">
            <label className="text-sm font-medium text-status-error">
              Email
            </label>
            <input
              type="email"
              placeholder="user@example.com"
              className="px-4 py-3 border rounded-lg outline-none focus:ring-2 focus:ring-status-warning"
            />
          </div>

          <div className="flex flex-col gap-2">
            <label className="text-sm font-medium">Password</label>
            <input
              type="password"
              placeholder="••••••••"
              className="px-4 py-3 border rounded-lg outline-none focus:ring-2 focus:ring-status-warning"
            />
          </div>

          <div className="flex items-center justify-between text-sm">
            <label className="flex items-center gap-2">
              <input type="checkbox" />
              Remember me
            </label>
            <span className="text-brand-primary cursor-pointer">
              Forgot password?
            </span>
          </div>

          <button className="w-full py-3 rounded-lg bg-status-success hover:bg-accent-hover text-text-muted font-semibold transition">
            Sign in
          </button>
        </div>

        {/* RIGHT SIDE */}
        <div className="w-1/2 bg-blue-600 flex items-center justify-center">
          <img
            src="https://plus.unsplash.com/premium_photo-1685134731588-783ca7471b65?q=80&w=1740&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            alt="login visual"
            className="object-cover h-full w-full"
          />
        </div>
      </div>
    </div>
  );
};

export default Signin;
