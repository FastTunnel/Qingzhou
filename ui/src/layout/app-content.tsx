import { Suspense } from 'react';
import { Outlet } from 'react-router-dom';
import PrivateRoute from './auth-router';
import { Loader2 } from 'lucide-react';

export function AppContent() {
  return <Suspense
    fallback={<Loader2 className="m-auto h-6 w-6 animate-spin" />}
  >
    <PrivateRoute>
      <Outlet></Outlet>
    </PrivateRoute>
  </Suspense>
}
