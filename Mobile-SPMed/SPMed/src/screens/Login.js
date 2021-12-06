import React, { Component } from 'react';
import {
    FlatList,
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    useColorScheme,
    TouchableOpacity,
    View,
    ImageBackground,
    TextInput,
} from 'react-native';

import {
    Colors,
    DebugInstructions,
    Header,
    LearnMoreLinks,
    ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';



//navigation
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
const bottomTab = createBottomTabNavigator();
import { NavigationContainer } from '@react-navigation/native';


import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';



export default class Login extends Component {

    constructor(props) {
        super(props)
        this.state = {
            email: '',
            senha: ''
        };
    }



    realizarLogin = () => {
        this.props.navigation.navigate('main')
    }


    render() {
        return (


            <ImageBackground
                source={(require('../../assets/img/Background.png'))}
                style={StyleSheet.absoluteFillObject}>



                <View>

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}
                    >

                        <Text>Login</Text>

                    </TouchableOpacity>
                </View>


            </ImageBackground>











        )
    }



}

const styles = StyleSheet.create({

    Main: {
        //flex: 1,
        //backgroundColor: '#F4F8FF',
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 240,
        backgroundColor: '#FFFFFF',
        borderColor: '#FFFFFF',
        borderWidth: 1,
        borderRadius: 7,
        shadowOffset: { height: 1, width: 1 },
    },


});
