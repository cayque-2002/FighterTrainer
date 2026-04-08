import { View, Text } from 'react-native';

export default function Home() {
  return (
    <View
      style={{
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        padding: 24,
      }}
    >
      <Text style={{ fontSize: 24, fontWeight: 'bold' }}>
        Fighter Trainer
      </Text>

      <Text style={{ marginTop: 12, fontSize: 16 }}>
        Front mobile iniciado com sucesso.
      </Text>
    </View>
  );
}