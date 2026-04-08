import { Stack } from 'expo-router';
import { AppProvider } from '@/src/providers/AppProvider';

export default function Layout() {
  return (
    <AppProvider>
      <Stack screenOptions={{ headerShown: false }} />
    </AppProvider>
  );
}